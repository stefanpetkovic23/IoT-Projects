const express = require("express");
const app = express();
const bodyParser = require("body-parser");
const City = require("./model");

app.use(bodyParser.json());

var PROTO_PATH = __dirname + "/cities.proto";

var grpc = require("@grpc/grpc-js");
var protoLoader = require("@grpc/proto-loader");

var packageDefinition = protoLoader.loadSync(PROTO_PATH, {
  keepCase: true,
  longs: String,
  enums: String,
  defaults: true,
  oneofs: true,
});

var protoDescriptor = grpc.loadPackageDefinition(packageDefinition);
var smartCitiesService = protoDescriptor.smart_cities.SmartCitiesService;

var client = new smartCitiesService(
  "localhost:5216",
  grpc.credentials.createInsecure()
);

app.get("/cities/:id", async (req, res) => {
  try {
    const cityId = req.params.id;
    // Pozivamo odgovarajuću metodu iz gRPC servisa
    client.GetCity({ id: cityId }, (err, response) => {
      if (err) {
        console.error("Greška prilikom poziva gRPC metode:", err);
        res
          .status(500)
          .json({ error: "Greška prilikom dobijanja podataka o gradu" });
        return;
      }
      res.json(response);
    });
  } catch (error) {
    console.error("Greška prilikom obrade zahteva:", error);
    res.status(500).json({ error: "Greška prilikom obrade zahteva" });
  }
});

app.get("/cities", async (req, res) => {
  try {
    // Pozivamo odgovarajuću metodu iz gRPC servisa
    client.GetAllCities({}, (err, response) => {
      if (err) {
        console.error("Greška prilikom poziva gRPC metode:", err);
        res
          .status(500)
          .json({ error: "Greška prilikom dobijanja svih gradova" });
        return;
      }
      res.json(response);
    });
  } catch (error) {
    console.error("Greška prilikom obrade zahteva:", error);
    res.status(500).json({ error: "Greška prilikom obrade zahteva" });
  }
});

// Metoda za dodavanje novog grada
app.post("/cities", async (req, res) => {
  try {
    const cityData = {
      city: req.body.city,
      country: req.body.country,
      smart_mobility: req.body.smart_mobility,
      smart_environment: req.body.smart_environment,
      smart_government: req.body.smart_government,
      smart_economy: req.body.smart_economy,
      smart_people: req.body.smart_people,
      smart_living: req.body.smart_living,
      smartcity_index: req.body.smartcity_index,
      smartcity_index_relative_edmonton:
        req.body.smartcity_index_relative_edmonton,
    };

    // Pozivamo odgovarajuću metodu iz gRPC servisa za dodavanje grada
    client.AddCity(cityData, (err, response) => {
      if (err) {
        console.error("Greška prilikom poziva gRPC metode:", err);
        res.status(500).json({ error: "Greška prilikom dodavanja grada" });
        return;
      }
      // Odgovor gRPC metode treba da sadrži identifikator novododatog grada
      const newCityId = response.id;
      res.json({ id: newCityId }); // Vraćamo ID novododatog grada kao odgovor
    });
  } catch (error) {
    console.error("Greška prilikom obrade zahteva:", error);
    res.status(500).json({ error: "Greška prilikom obrade zahteva" });
  }
});

// Metoda za ažuriranje postojećeg grada
app.put("/cities/:id", async (req, res) => {
  try {
    const cityId = req.params.id;
    const cityData = req.body;
    // Pozivamo odgovarajuću metodu iz gRPC servisa
    client.UpdateCity({ id: cityId, ...cityData }, (err, response) => {
      if (err) {
        console.error("Greška prilikom poziva gRPC metode:", err);
        res
          .status(500)
          .json({ error: "Greška prilikom ažuriranja podataka o gradu" });
        return;
      }
      res.json(response);
    });
  } catch (error) {
    console.error("Greška prilikom obrade zahteva:", error);
    res.status(500).json({ error: "Greška prilikom obrade zahteva" });
  }
});

// Metoda za brisanje grada
app.delete("/cities/:id", async (req, res) => {
  try {
    const cityId = req.params.id;
    // Pozivamo odgovarajuću metodu iz gRPC servisa
    client.DeleteCity({ id: cityId }, (err, response) => {
      if (err) {
        console.error("Greška prilikom poziva gRPC metode:", err);
        res
          .status(500)
          .json({ error: "Greška prilikom brisanja podataka o gradu" });
        return;
      }
      res.json(response);
    });
  } catch (error) {
    console.error("Greška prilikom obrade zahteva:", error);
    res.status(500).json({ error: "Greška prilikom obrade zahteva" });
  }
});

// Pokretanje servera na određenom portu
const port = 3000;
app.listen(port, () => {
  console.log(`Server je pokrenut na portu ${port}`);
});
