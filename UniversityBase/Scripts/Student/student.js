$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: "/Home/JsonStudent",
        success: function (data)
        {
            
            var students = $.parseJSON(data);
            
            for (var i = 0; i < students.length; i++)
            {
                var value = String(students[i].Id);
                var str1 = '  <input type="hidden" id="Id" name="Id" ';
                var str2 = 'value="';
                var str3 = '"';
                var str4 = '>';

                var strResult1 = str1 + str2 + value + str3 + str4;

                $("#Students").append('<tr >'
                    + '<td>' + students[i].Name + '</td>'
                    + '<td>' + students[i].Surname + '</td>'
                    + '<td>' + students[i].AgeOfBirth + '</td>'
                    + '<td>' + students[i].Course + '</td>'
                    + '<td>' + students[i].Age + '</td>'
                    + '<td>' + students[i].Group + '</td>'
                    + '<td  >' + '<form action="/Edit/EditStudent" method="post" >' + strResult1 + '  <input type="submit" value="Edit">' + '</form>' + '</td>'
                    + '<td  >' + '<form action="/Edit/DeleteStudent" method="post" method="post" onsubmit="return WannaReally()">' + strResult1 + '  <input type="submit" value="Delete">' + '</form>' + '</td>'

                    + '</tr>');

            }
        }
        
    });
});