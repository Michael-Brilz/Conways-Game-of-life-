const url = "http://localhost:5238/nextGeneration"

//POST
const asyncPostTestApi = async (jsonData) => {
  console.log(jsonData)
 
    fetch(url + "?oldGeneration="+ JSON.stringify(jsonData).replaceAll(";","%3B").replaceAll("\"", ""),  {
      method: "POST",
      referrer: "",
      mode: "no-cors", 
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Headers": "Origin, X-Requested-With, Content-Type, Accept",
        "accept": 'application/json',
        "Content-Type": "application/json html/text"
      }
    }).then((response) => response.json())
    .then((json) => {
      var testArray = json
      console.log(testArray)
      callGrid(testArray)
    });

}