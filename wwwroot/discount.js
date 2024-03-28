document.addEventListener("DOMContentLoaded", function () {
    // preload audio
    var toastSound = new Audio('mixkit-correct-answer-reward-952.wav');

    const liveToastElement = document.getElementById('liveToast');

    const toastCodeElement = document.getElementById('code');
    const toastProductElement = document.getElementById('product');
    const toastTitleElement = document.getElementById('title');

    document.getElementById('discount-row').addEventListener('click', function (e) {
        if (e.target.classList.contains('discount')) {
            toastSound.pause();

            e.preventDefault();
            toastCodeElement.innerText = e.target.dataset['code'];
            toastProductElement.innerText = e.target.dataset['product'];
            toastTitleElement.innerText = e.target.dataset['title'];
            bootstrap.Toast.getOrCreateInstance(liveToastElement).show();

            // reset the audio
            toastSound.currentTime = 0;
            // play audio
            toastSound.play();
        }
    });

    document.addEventListener("keydown", (event) => {
        // console.log(event.key);
        if (event.isComposing || event.key === 'Escape') {
            bootstrap.Toast.getOrCreateInstance(liveToastElement).hide();
        }
    });
});
