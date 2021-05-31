var timer;
var percent = 0;
var audio_1 = document.getElementById("audio_1");//audio
var audio_2 = document.getElementById("audio_2");//audio
var audio_3 = document.getElementById("audio_3");//audio
var audio_4 = document.getElementById("audio_4");//audio
var audio_5 = document.getElementById("audio_5");//audio
var audio_6 = document.getElementById("audio_6");//audio
var audio_7 = document.getElementById("audio_7");//audio
var audio_8 = document.getElementById("audio_8");//audio
var audio_9 = document.getElementById("audio_9");//audio
var audio_10 = document.getElementById("audio_10");//audio
var audio_11 = document.getElementById("audio_11");//audio
var audio_12 = document.getElementById("audio_12");//audio
var audio_13 = document.getElementById("audio_13");//audio
var audio_14 = document.getElementById("audio_14");//audio
var audio_15 = document.getElementById("audio_15");//audio
var audio_16 = document.getElementById("audio_16");//audio
var audio_17 = document.getElementById("audio_17");//audio

//var audios = ["audio_1", "audio_2", "audio_3"]

audio_1.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_1);
});
audio_1.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});

audio_2.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_2);
});
audio_2.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});

audio_3.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_3);
});
audio_3.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_4.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_4);
});
audio_4.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_5.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_5);
});
audio_5.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_6.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_6);
});
audio_6.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_7.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_7);
});
audio_7.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_8.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_8);
});
audio_8.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_9.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_9);
});
audio_9.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_10.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_10);
});
audio_10.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_11.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_11);
});
audio_11.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_12.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_12);
});
audio_12.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_13.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_13);
});
audio_13.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_14.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_14);
});
audio_14.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_15.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_15);
});
audio_15.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_16.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_16);
});
audio_16.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});
audio_17.addEventListener("playing", function(_event) {
  var duration = _event.target.duration;
  advance(duration, audio_17);
});
audio_17.addEventListener("pause", function(_event) {
  clearTimeout(timer);
});


//Inicio();

// function Inicio() {
//   console.log("dfsd");
//   for (var i = 0; i < 3; i++) {
//     var audio = document.getElementById(audios[i]);
//     console.log(i);
//     audio.addEventListener("playing", function(_event) {
//         var duration = _event.target.duration;
//         advance(duration, audio);
//       });

//     audio.addEventListener("pause", function(_event) {
//        clearTimeout(timer);
//     });
//   }
// }
var advance = function (duration, element) {    
  var padreAudio = element.closest("div > div");
  var padre = padreAudio.parentNode;
  var nodeList = padre.childNodes;
  var progress = nodeList[5];
  
  increment = 10/duration;
  percent = Math.min(increment * element.currentTime * 10, 100);
  progress.style.width = percent+'%'
  startTimer(duration, element);
}
var startTimer = function(duration, element){ 
  if (percent < 100)
  {
    timer = setTimeout(function (){advance(duration, element)}, 100);   
  }
}

function togglePlay(e) {
  
  e = e || window.event;
  var btn = e.target;
  allpause(btn);
  var audioId = btn.id;
  audio = document.getElementById(audioId);
  if (!audio.paused) {
    btn.classList.remove('active');
    audio.pause();
    isPlaying = false;
  } else {
    btn.classList.add('active');
    audio.play();
    isPlaying = true;
  }
}

function allpause(e)
{
  for (var i = 1; i <= 17; i++) {
    var audioAuxiliar = document.getElementById("audio_" + i);
    var auxId = "audio_" + i;
    if (e.id != auxId) {

      var padreAudio = audioAuxiliar.closest("div > div");
      var padre = padreAudio.parentNode;
      var nodeList = padre.childNodes;
      var progress = nodeList[7];
      var controles = progress.childNodes;
      var play = controles[3];
      var playBtn = play.childNodes;
      var imgPlay = playBtn[1];
      //console.log(imgPlay);
      imgPlay.classList.remove('active');
      audioAuxiliar.pause();
    }
  }
}

function secondsToHms(timestamp) {
        var hours = Math.floor(timestamp / 60 / 60);
        var minutes = Math.floor((timestamp / 60) - (hours * 60));
        var seconds = Math.floor(timestamp % 60);
        var formatted = minutes.toString().padStart(2, '0') + ':' + seconds.toString().padStart(2, '0');
        return formatted;
}