$(function () {
    $("ul li ul li").hover(function () {
        $(this).css("backgroundColor", "#FDAF05");
        $(this).children("a").css("color", "white");
    },
        function () {
            $(this).css("backgroundColor", "#D6D6D6");
            $(this).children("a").css("color", "black");
        }
    );
    $(".main > a").click(function () {
        var ulNode = $(this).next("ul");
        ulNode.slideToggle();
        changeIcon($(this));
    }
    );


    function changeIcon(mainNode) {
        if (mainNode) {
            if (mainNode.css("background-image").indexOf("arrow1") >= 0) {
                mainNode.css("background-image", "url('../../Admin/Images/arrow2.jpg')")
            }
            else {
                mainNode.css("background-image", "url('../../Admin/Images/arrow1.jpg')")
            }
        }
    }
}
)