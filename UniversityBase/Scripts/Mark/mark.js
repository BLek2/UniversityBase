$(document).ready(function () {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        url: '/Home/JsonMark',
        success: function (data) {
            var marks = $.parseJSON(data);

            for (var i = 0; i < marks.length; i++){

                if (marks[i].Math == null) {
                    marks[i].Math = '';
                }

                if (marks[i].History == null) {
                    marks[i].History = '';
                }

                if (marks[i].Psychology == null) {
                    marks[i].Psychology = '';
                }

                if (marks[i].Literature == null) {
                    marks[i].Literature = '';
                }

                if (marks[i].Cooking == null) {
                    marks[i].Cooking = '';
                }

                if (marks[i].Music == null) {
                    marks[i].Music = '';
                }

                if (marks[i].Law == null) {
                    marks[i].Law = '';
                }

                if (marks[i].Programming == null) {
                    marks[i].Programming = '';
                }

                if (marks[i].WebDesign == null) {
                    marks[i].WebDesign = '';
                }

                var value = String(marks[i].Id);

                var str1 = '  <input type="hidden" id="Id" name="Id" ';
                var str2 = 'value="';
                var str3 = '"';
                var str4 = '>';
               
                var strResult1 = str1 + str2 + value + str3 + str4;

                $("#Marks").append('<tr >'
                    + '<td>' + marks[i].Math + '</td>'
                    + '<td>' + marks[i].History + '</td>'
                    + '<td>' + marks[i].Psychology + '</td>'
                    + '<td>' + marks[i].Literature + '</td>'
                    + '<td>' + marks[i].Cooking + '</td>'
                    + '<td>' + marks[i].Music + '</td>'
                    + '<td>' + marks[i].Law + '</td>'
                    + '<td>' + marks[i].Programming + '</td>'
                    + '<td>' + marks[i].WebDesign + '</td>'
                    + '<td>' + marks[i].Student + '</td>'
                    + '<td  >' + '<form action="/Edit/EditMark" method="post" >' + strResult1 + '  <input type="submit" value="Edit">' + '</form>' + '</td>'
                    + '<td  >' + '<form action="/Edit/DeleteMark" method="post" method="post" onsubmit="return WannaReally()">' + strResult1 + '  <input type="submit" value="Delete">' + '</form>' + '</td>'

                    + '</tr>');    
            }       
        }
    });
   
});
