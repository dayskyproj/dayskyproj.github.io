function FooterResized(dotnethelper) {
    function padPageElement() {
        document.getElementsByClassName("main")[0].style.paddingBottom = 30 + "px";
    }
    var footerElm = document.getElementById("footer");
    new ResizeObserver(padPageElement).observe(footerElm);
}