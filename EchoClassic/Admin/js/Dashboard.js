function LiveAttendanceCounter() {
   // alert(2);
    var param = "";
    // param: JSON.stringify({ "Date": "12/12/2019", "ClientID": 12, "Session": "2019-2020" });
    //alert(param);
    var ClientID = $('#litClientID').val();
    
    $.ajax({
        type: "POST",
        url: "../Service1.svc/AttendanceLiveCounter",
        data: JSON.stringify({ "ClientID": ClientID }),
        contentType: "application/json; charset=utf-8", 
        dataType: "json",
        success: function (msg) {
            
            if (msg.AttendanceLiveCounterResult != "") {
               // alert(msg.AttendanceLiveCounterResult);
                $('#txtinput').val(msg.AttendanceLiveCounterResult);
            }
            else {
                
            }
        }

    });
}