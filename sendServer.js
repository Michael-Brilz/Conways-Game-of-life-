const url = "http://localhost:5238/nextGeneration";

//POST
const asyncPostCall = async (jsonData) => {
  console.log(jsonData);

  fetch(
    url +
      "?oldGeneration=" +
      JSON.stringify(jsonData).replaceAll(";", "%3B").replaceAll('"', ""),
    {
      method: "POST",
      cache: "no-cache",
      mode: "cors",
      headers: {
        accept: "application/json",
        "Content-Type": "application/json html/text",
      },
    }
  )
    .then((response) => response.text())
    .then((response) => {
      parseGameField(response);
    });
};
