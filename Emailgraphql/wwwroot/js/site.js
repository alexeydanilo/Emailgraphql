$.ajax({
    url: "https://localhost:44318/graphql",
    contentType: "application/json", type: 'POST',
    data: JSON.stringify({
        query: ` query { emails{
    sentTo
    status
  } }`
    }),
    success: function (result) {

        for (var i = 0; i < result.data.emails.length; i++) {
            $("#StatusTable").append('<tr>' + '<td>' + result.data.emails[i].sentTo + '</td>' + '<td>' + result.data.emails[i].status + '</td>' + '</tr')
        }
        
           
       
    }
});


