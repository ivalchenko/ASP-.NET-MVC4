//$(document).ready(function(){

    //alert("Заработал мой скрипт!");
    var inProgress = false;

    window.module = {
      like: function (postId) {
        alert("Нажали на кнопку!");
        inProgress = true;
        ajaxLike(postId);
      }
    }

    function ajaxLike(){

        if (inProgress) 
        {
            alert("Пошел AJAX!");

              $.ajax({
                    url: "/Posts/AJAXLike",
                    method: 'POST',
                    data: {"postId" : postId}
                });
        }
    } 
//});