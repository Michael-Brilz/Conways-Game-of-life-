var rows = 10;
var cols = 10;
var playing = true;
var grid = new Array(rows);
var nextGrid = new Array(rows);


// init break button
var breakButton = document.getElementById("break");
breakButton.addEventListener("click", (event) => {
  breakGame();
});
// break Game
function breakGame() {
  playing = false;
}

// Method for POST, GET
function callGrid(testArray) {
  console.log(testArray);
  clearGrid();
  initializeGrids();
  sendGridTable(testArray);

  // Lay out the board
  function sendGridTable(testArray) {
    var gridContainer = document.getElementById("gridContainer");
    if (!gridContainer) {
      // Throw error
      console.error("Problem: No div for the drid table!");
    }

    var table = document.createElement("table");
    for (var i = 0; i < rows; i++) {
      var tr = document.createElement("tr");
      for (var j = 0; j < rows; j++) {
        var cell = document.createElement("td");
        cell.setAttribute("id", i + "_" + j);
        if (testArray[i][j] === "1") {
          cell.setAttribute("class", "live");
          // generatedCells(i, j);
        } else {
          cell.setAttribute("class", "dead");
        }

        tr.appendChild(cell);
      }
      table.appendChild(tr);
    }
    gridContainer.appendChild(table);
    parseGame(testArray);
  }
  // Parse the Array to String
  function parseGame(parseObject) {
    var firstString = parseObject.join(";");
    secondString = firstString.replaceAll(",", "");
    thirdString = secondString.concat(";");
    asyncPostCall(thirdString);
  }
}
// Clear the Layout for new Iteration
function clearGrid() {
  document.getElementById("gridContainer").innerHTML = "";
}

