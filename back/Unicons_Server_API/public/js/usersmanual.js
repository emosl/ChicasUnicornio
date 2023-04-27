window.addEventListener('scroll', function () {
    var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
    var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
    var scrollPercent = scrollTop / height;
  
    var overlay = document.getElementById('overlay');
    var alpha = Math.min(scrollPercent * 2, 0.8);
    overlay.style.backgroundColor = 'rgba(0, 0, 0, ' + alpha + ')';
  });