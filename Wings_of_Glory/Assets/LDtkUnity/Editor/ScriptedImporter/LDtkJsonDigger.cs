﻿using System.Collections.Generic;
using System.IO;
using UnityEngine.Assertions;
using UnityEngine.Profiling;
using JsonReader = Utf8Json.JsonReader;
using JsonToken = Utf8Json.JsonToken;

namespace LDtkUnity.Editor
{
    internal static class LDtkJsonDigger
    {
        //todo all of the data digging could be merged into one big json sweep, so that we are not starting multiple streams and can still get everything necessary for performance
        //todo also we might be able to cache the loaded bytes for multiple operations perhaps
        private delegate bool JsonDigAction<T>(ref JsonReader reader, ref T result);

        public static bool GetTilesetRelPaths(string projectPath, ref HashSet<string> result) => 
            DigIntoJson(projectPath, GetTilesetRelPathsReader, ref result);
        public static bool GetUsedEntities(string path, ref HashSet<string> result) => 
            DigIntoJson(path, GetUsedEntitiesReader, ref result);
        public static bool GetUsedIntGridValues(string path, ref HashSet<string> result) => 
            DigIntoJson(path, GetUsedIntGridValuesReader, ref result);
        public static bool GetUsedBackgrounds(string path, ref HashSet<string> result) => 
            DigIntoJson(path, GetUsedBackgroundsReader, ref result);
        public static bool GetUsedFieldTiles(string levelPath, ref List<FieldInstance> result) => 
            DigIntoJson(levelPath, GetUsedFieldTilesReader, ref result);
        public static bool GetUsedTilesetSprites(string levelPath, ref Dictionary<string, HashSet<int>> result) => 
            DigIntoJson(levelPath, GetUsedTilesetSpritesReader, ref result);
        public static bool GetIsExternalLevels(string projectPath, ref bool result) => 
            DigIntoJson(projectPath, GetIsExternalLevelsInReader, ref result);
        public static bool GetDefaultGridSize(string projectPath, ref int result) => 
            DigIntoJson(projectPath, GetDefaultGridSizeInReader, ref result);
        public static bool GetJsonVersion(string projectPath, ref string result) => 
            DigIntoJson(projectPath, GetJsonVersionReader, ref result);
        
        private static bool DigIntoJson<T>(string path, JsonDigAction<T> digAction, ref T result)
        {
            Profiler.BeginSample($"DigIntoJson {digAction.Method.Name}");
            
            if (!File.Exists(path))
            {
                LDtkDebug.LogError($"Couldn't locate the file to dig into the json for at path: \"{path}\"");
                return false;
            }
            
            byte[] bytes = File.ReadAllBytes(path);
            JsonReader reader = new JsonReader(bytes);
            bool success = digAction.Invoke(ref reader, ref result);

            Profiler.EndSample();

            if (success)
            {
                //Debug.Log($"Dug json and got {result} for {actionThing.Method.Name} at {path}");
                return true;
            }
            
            LDtkDebug.LogError($"Issue digging into the json for {path}");
            return false;
        }
        
        private static bool GetJsonVersionReader(ref JsonReader reader, ref string result)
        {
            while (reader.Read())
            {
                if (reader.ReadIsPropertyName("jsonVersion"))
                {
                    result = reader.ReadString();
                    return true;
                }
            }
            return false;
        }
        
        private static bool GetIsExternalLevelsInReader(ref JsonReader reader, ref bool result)
        {
            while (reader.Read())
            {
                if (reader.ReadIsPropertyName("externalLevels"))
                {
                    result = reader.ReadBoolean();
                    return true;
                }
            }
            return false;
        }

        private static bool GetDefaultGridSizeInReader(ref JsonReader reader, ref int result)
        {
            while (reader.Read())
            {
                if (reader.ReadIsPropertyName("defaultGridSize"))
                {
                    result = reader.ReadInt32();
                    return true;
                }
            }
            return false;
        }
        
        private static bool GetUsedBackgroundsReader(ref JsonReader reader, ref HashSet<string> result)
        {
            while (reader.Read())
            {
                if (!reader.ReadIsPropertyName("bgRelPath"))
                {
                    continue;
                }
                
                string value = reader.ReadString();
                if (!string.IsNullOrEmpty(value))
                {
                    result.Add(value);
                }
            }
            return true;
        }
        
        private static bool GetTilesetRelPathsReader(ref JsonReader reader, ref HashSet<string> textures)
        {
            while (reader.Read())
            {
                if (!reader.ReadIsPropertyName("tilesets"))
                {
                    continue;
                }
                
                while (reader.CanRead())
                {
                    int depth = 0;
                    while (reader.IsInArray(ref depth))
                    {
                        if (reader.GetCurrentJsonToken() != JsonToken.String)
                        {
                            reader.ReadNext();
                            continue;
                        }

                        if (reader.ReadString() == "relPath" && reader.ReadIsNameSeparator())
                        {
                            string value = reader.ReadString();
                            if (!string.IsNullOrEmpty(value)) //doing null check because the embedded icons atlas is null string
                            {
                                textures.Add(value);
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        
        private static bool GetUsedEntitiesReader(ref JsonReader reader, ref HashSet<string> entities)
        {
            // For entities example, we expect:
            // "Button","TriggerArea""SpotLight","Door","Repeater","MessagePopUp","Exit","Chest","Enemy","Teleporter","PlayerStart","Item",
            
            while (reader.Read())
            {
                if (!reader.ReadIsPropertyName("entityInstances"))
                {
                    continue;
                }
                
                int arrayDepth = 0;
                while (reader.IsInArray(ref arrayDepth))
                {
                    if (reader.GetCurrentJsonToken() == JsonToken.ValueSeparator)
                    {
                        reader.ReadNext();
                    }

                    int objectDepth = 0;
                    while (reader.IsInObject(ref objectDepth))
                    {
                        if (objectDepth != 1)
                        {
                            reader.ReadNext();
                            continue;
                        }
                        
                        if (reader.GetCurrentJsonToken() != JsonToken.String)
                        {
                            reader.ReadNext();
                            continue;
                        }

                        if (reader.ReadString() == "__identifier" && reader.ReadIsNameSeparator())
                        {
                            entities.Add(reader.ReadString());
                        }
                    }
                }
            }
            
            //its possible to get none if the project uses separate level files
            return true;
        }
        
        private static bool GetUsedIntGridValuesReader(ref JsonReader reader, ref HashSet<string> result)
        {
            string recentIdentifier = "";
            
            while (reader.CanRead())
            {
                if (reader.GetCurrentJsonToken() != JsonToken.String)
                {
                    reader.ReadNext();
                    continue;
                }

                string propName = reader.ReadString();

                if (propName == "__identifier" && reader.ReadIsNameSeparator())
                {
                    recentIdentifier = reader.ReadString();
                    continue;
                }
                
                if (propName == "intGridCsv" && reader.ReadIsNameSeparator())
                {
                    int depth = 0;
                    while (reader.IsInArray(ref depth))
                    {
                        long intGridValue = reader.ReadInt64();
                        string formattedString = LDtkKeyFormatUtil.IntGridValueFormat(recentIdentifier, intGridValue.ToString());
                        result.Add(formattedString);
                        reader.ReadIsValueSeparator();
                    }
                }
            }
            
            return true;
        }
        
        private static bool GetUsedTilesetSpritesReader(ref JsonReader reader, ref Dictionary<string, HashSet<int>> usedTileIds)
        {
            //only gets used art tiles from tiles/auto/intgrid layers, not fields
            // In a layer, contains AutoLayerTiles and GridTiles.
            //TileInstance contains the rect, but also a T value that might be usable. 

            while (reader.Read())
            {
                //1. find a layer instance and record the name of the layer. we could encounter the same layer name again, so track the dictionary accordingly.
                //layerInstances is an array of objects. 
                if (!reader.ReadIsPropertyName("layerInstances"))
                {
                    continue;
                }
                
                //at this point in time: We've just found the layer instances array.
                //need to see if the layer has start objects or if it's just an empty array.
                //this while loop is looking for the end of the layerinstances array
                //this while look is to look into the layerinstances array. it is always either one of two things:
                //-EndArray because the LayerInstances was empty
                //-StartObject because there's content in the LayerInstances array
                
                //layerInstances could be null if we're a project using separate levels. in which case, there's no tile data to find in this one
                if (reader.ReadIsNull())
                {
                    return true;
                }

                Assert.IsTrue(reader.GetCurrentJsonToken() == JsonToken.BeginArray);
                int layerInstancesArrayDepth = 0;
                while (reader.ReadIsInArray(ref layerInstancesArrayDepth)) //endarray handled automatically if array is empty
                {
                    //in case we're going to the next layer instance
                    reader.ReadIsValueSeparator();

                    //100% a start object of a layer instance
                    Assert.IsTrue(reader.GetCurrentJsonToken() == JsonToken.BeginObject);
                    int layerInstanceObjectDepth = 0;

                    while (reader.IsInObject(ref layerInstanceObjectDepth))
                    {
                        //__identifier
                        Assert.IsTrue(reader.ReadIsPropertyName("__identifier"));
                        string identifier = reader.ReadString();
                        Assert.IsTrue(reader.ReadIsValueSeparator());
                        Assert.IsTrue(!string.IsNullOrEmpty(identifier));
                        
                        //__type
                        Assert.IsTrue(reader.ReadIsPropertyName("__type"));
                        string type = reader.ReadString();
                        Assert.IsTrue(reader.ReadIsValueSeparator());
                        
                        //3. Depending on type, go into the appropriate tile array. AutoLayer/IntGrid: AutoLayerTiles, TilesLayer: GridTiles
                        //(possible values: IntGrid, Entities, Tiles or AutoLayer)
                        if (type != "IntGrid" &&
                            type != "Tiles" &&
                            type != "AutoLayer")
                        {
                            reader.ReadToObjectEnd(layerInstanceObjectDepth);
                            break;
                        }
                        
                        HashSet<int> tileIds;
                        if (usedTileIds.ContainsKey(identifier))
                        {
                            tileIds = usedTileIds[identifier];
                        }
                        else
                        {
                            tileIds = new HashSet<int>();
                            usedTileIds.Add(identifier, tileIds);
                        }

                        string arrayToSearch = null;
                        switch (type)
                        {
                            case "IntGrid": arrayToSearch = "autoLayerTiles"; break;
                            case "Tiles": arrayToSearch = "gridTiles"; break;
                            case "AutoLayer": arrayToSearch = "autoLayerTiles"; break;
                            default:
                                LDtkDebug.LogError($"Expected type wasn't properly encountered {type}");
                                break;
                        }
                        Assert.IsTrue(!string.IsNullOrEmpty(arrayToSearch));

                        //iterate until we reach the tile array 
                        while (!reader.ReadIsPropertyName(arrayToSearch))
                        {
                            reader.ReadNext();
                        }

                        //4. Keep on iterating through the array, grabbing every "t" value and adding to the hashset for this layer.
                        int tileArrayDepth = 0;
                        while (reader.IsInArray(ref tileArrayDepth))
                        {
                            if (reader.GetCurrentJsonToken() != JsonToken.BeginObject)
                            {
                                reader.ReadNext();
                                continue;
                            }

                            int tileInstanceDepth = 0;
                            while (reader.IsInObject(ref tileInstanceDepth))
                            {
                                if (reader.ReadIsPropertyName("t"))
                                {
                                    tileIds.Add(reader.ReadInt32());
                                    reader.ReadToObjectEnd(tileInstanceDepth);
                                    break;
                                }
                                reader.ReadNext();
                            }
                        }
                        //we will now look for the next endobject so that the while loop can attempt again in case we hit another start array.
                        reader.ReadToObjectEnd(layerInstanceObjectDepth);
                        break;
                    }
                    //when exiting out, we should be in a state of having been to the next array element, or we reached the end of the array and we can then exit out of the array and look for the next layerinstances somewhere.
                    //end object
                    //5. After reaching the end of the tiles array in this layer instance, try to find another object within this array, else exit out.
                }
            }
            
            return true;
        }
        
        private static bool GetUsedFieldTilesReader(ref JsonReader reader, ref List<FieldInstance> result)
        {
            //a field instance: { "__identifier": "integer", "__value": 12345, "__type": "Int", "__tile": null, "defUid": 105, "realEditorValues": [{ "id": "V_Int", "params": [12345] }] },
            //"fieldInstances": [{ "__identifier": "LevelTile", "__value": { "tilesetUid": 149, "x": 96, "y": 32, "w": 32, "h": 16 }, "__type": "Tile", "__tile": { "tilesetUid": 149, "x": 96, "y": 32, "w": 32, "h": 16 }, "defUid": 164, "realEditorValues": [{"id": "V_String","params": ["96,32,32,16"]}] }]
            while (reader.Read())
            {
                if (!reader.ReadIsPropertyName("fieldInstances"))
                {
                    continue;
                }
                
                Assert.IsTrue(reader.GetCurrentJsonToken() == JsonToken.BeginArray);
                
                int arrayDepth = 0;

                while (reader.IsInArray(ref arrayDepth)) //fieldInstances array. 
                {
                    //in case we're in the next object
                    reader.ReadIsValueSeparator();
                    
                    Assert.IsTrue(reader.GetCurrentJsonToken() == JsonToken.BeginObject);
                    int fieldInstanceObjectDepth = 0;
                    while (reader.IsInObject(ref fieldInstanceObjectDepth))
                    {
                        FieldInstance field = new FieldInstance();
                
                        //_identifier
                        Assert.IsTrue(reader.ReadIsPropertyName("__identifier"));
                        field.Identifier = reader.ReadString();
                        Assert.IsTrue(reader.ReadIsValueSeparator());
                        
                        //__value
                        Assert.IsTrue(reader.ReadIsPropertyName("__value"));

                        //start object or start array, or null. if it's null, and in which that case, then we're done digging in this one.
                        if (reader.ReadIsNull())
                        {
                            reader.ReadToObjectEnd(fieldInstanceObjectDepth);
                            break;
                        }
                        
                        List<TilesetRectangle> rects = new List<TilesetRectangle>();
                        bool isArray = reader.GetCurrentJsonToken() == JsonToken.BeginArray;
                        if (isArray)
                        {
                            int valueArrayDepth = 0;
                            while (reader.IsInArray(ref valueArrayDepth))
                            {
                                reader.ReadIsValueSeparator();
                                ReadTilesetRectangleObject(ref reader);
                            }
                        }
                        else
                        {
                            ReadTilesetRectangleObject(ref reader);
                        }
                        field.Value = rects.ToArray();
                        
                        void ReadTilesetRectangleObject(ref JsonReader readerInScope)
                        {
                            if (readerInScope.ReadIsNull())
                            {
                                return;
                            }
                            
                            if (!readerInScope.ReadIsBeginObject())
                            {
                                readerInScope.ReadNext();
                                return;
                            }
                            
                            //tilesetUid. do a check here because it could be the point field
                            Assert.IsTrue(readerInScope.GetCurrentJsonToken() == JsonToken.String);
                            if (readerInScope.ReadString() != "tilesetUid")
                            {
                                readerInScope.ReadToObjectEnd(1);
                                return;
                            }
                            TilesetRectangle rect = new TilesetRectangle();
                            Assert.IsTrue(readerInScope.ReadIsNameSeparator());
                            
                            rect.TilesetUid = readerInScope.ReadInt32();
                            Assert.IsTrue(readerInScope.ReadIsValueSeparator());

                            //x
                            Assert.IsTrue(readerInScope.ReadIsPropertyName("x"));
                            rect.X = readerInScope.ReadInt32();
                            Assert.IsTrue(readerInScope.ReadIsValueSeparator());

                            //y
                            Assert.IsTrue(readerInScope.ReadIsPropertyName("y"));
                            rect.Y = readerInScope.ReadInt32();
                            Assert.IsTrue(readerInScope.ReadIsValueSeparator());

                            //w
                            Assert.IsTrue(readerInScope.ReadIsPropertyName("w"));
                            rect.W = readerInScope.ReadInt32();
                            Assert.IsTrue(readerInScope.ReadIsValueSeparator());

                            //h
                            Assert.IsTrue(readerInScope.ReadIsPropertyName("h"));
                            rect.H = readerInScope.ReadInt32();
                            
                            readerInScope.ReadIsEndObjectWithVerify();
                            rects.Add(rect);
                        }
                        
                        //__type
                        reader.ReadUntilPropertyName("__type");
                        field.Type = reader.ReadString();

                        if (field.Type != "Tile" && field.Type != "Array<Tile>")
                        {
                            reader.ReadToObjectEnd(fieldInstanceObjectDepth);
                            break;
                        }
                        Assert.IsTrue(reader.ReadIsValueSeparator());
                        
                        //defUid
                        reader.ReadUntilPropertyName("defUid");
                        field.DefUid = reader.ReadInt32();
                        
                        result.Add(field);
                        reader.ReadToObjectEnd(fieldInstanceObjectDepth);
                        break;
                    }
                }
            }
            return true;
        }
    }
}