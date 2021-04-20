grecaptcha.ready(function () {
    window.grecaptcha.execute('@Configuration["googleReCaptcha:SiteKey"]', { action: 'home' }).then(function (token) {
        $("#captchaInput").val(token);
    });
});