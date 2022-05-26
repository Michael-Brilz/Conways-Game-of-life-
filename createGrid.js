var rows = 10;
var cols = 10;

var grid = new Array(rows);
var nextGrid = new Array(rows);

var startButton = document.getElementById("start");
startButton.addEventListener("click", (event) => {
  initialize();
});
var sendButton = document.getElementById("send");
sendButton.addEventListener("click", (event) => {
  sendGrid();
});

//Create Multidimensional Array
function initializeGrids() {
  for (var i = 0; i < rows; i++) {
    grid[i] = new Array(cols);
    nextGrid[i] = new Array(cols);
  }
}

// Initialize
function initialize() {
  createTable();
  initializeGrids();
}
//send Grid to sendServer
function sendGrid() {
  converdGrid(grid);
}
// Create Array to Binary String
function converdGrid(g) {
  var withoutCommas = g.join(";").replaceAll("", "0");
  firstArray = withoutCommas.replaceAll("010", "1");
  secondArray = firstArray.replaceAll(",", "");
  thirdArray = secondArray.concat(";");
  console.log(thirdArray);
  asyncPostCall(thirdArray);
}

// Lay out the board
function createTable() {
  var gridContainer = document.getElementById("gridContainer");
  if (!gridContainer) {
    // Throw error
    console.error("Problem: No div for the drid table!");
  }
  var table = document.createElement("table");

  for (var i = 0; i < rows; i++) {
    var tr = document.createElement("tr");
    for (var j = 0; j < cols; j++) {
      var cell = document.createElement("td");
      cell.setAttribute("id", i + "_" + j);
      cell.setAttribute("class", "dead");
      cell.onclick = cellClickHandler;
      tr.appendChild(cell);
    }
    table.appendChild(tr);
  }
  gridContainer.appendChild(table);
  function cellClickHandler() {
    var rowcol = this.id.split("_");
    var row = rowcol[0];
    var col = rowcol[1];

    var classes = this.getAttribute("class");
    if (classes.indexOf("live") > -1) {
      this.setAttribute("class", "dead");
      grid[row][col] = 0;
    } else {
      this.setAttribute("class", "live");
      grid[row][col] = 1;
    }
  }
}
