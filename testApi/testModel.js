var testApiModel = {
    rows:  '10',
    columns: '10',
    activeCells: []
}

function generatedCells(c, r)
{
    this.c = c
    this.r = r
    var aCell = {
        "c": c,
        "r": r
    }
 testApiModel.activeCells.push(aCell)
 asyncPostTestApi(testApiModel)
 }
