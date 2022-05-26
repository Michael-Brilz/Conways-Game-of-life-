// Decode the Response String to Array

function parseGameField(gameFieldString) {
    var parsedGameFields = [];
    var tempRow = [];
    for (var i = 1; i < gameFieldString.length; i++) {
        if(gameFieldString.charAt(i) === ";") {
            parsedGameFields.push(tempRow);
            tempRow = [];
        }else {
            if(gameFieldString.charAt(i) === "X") {
                tempRow.push('1');
            } else {
                tempRow.push('0');
            }
        }
    }  
    // Call the Server all 2 seconds
    setTimeout(function(){
        callGrid(parsedGameFields)
      }, 2000);
   
}


