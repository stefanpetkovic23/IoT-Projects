/*const express = require("express");
const bodyParser = require("body-parser");
const db = require("./db");

const app = express();
const PORT = process.env.PORT || 3000;

app.use(bodyParser.json());

app.get("/cities", async (req, res) => {
  try {
    const cities = await db.getAllCities();
    res.json(cities);
  } catch (error) {
    console.error("Greška prilikom dobijanja gradova iz baze podataka:", error);
    res
      .status(500)
      .json({ error: "Greška prilikom dobijanja gradova iz baze podataka." });
  }
});

// Endpoint za dobijanje grada po ID-u
app.get("/cities/:id", async (req, res) => {
  const cityId = parseInt(req.params.id);
  try {
    const city = await db.getCityById(cityId);
    if (city) {
      res.json(city);
    } else {
      res.status(404).json({ error: "Grad nije pronađen." });
    }
  } catch (error) {
    console.error("Greška prilikom dobijanja grada iz baze podataka:", error);
    res
      .status(500)
      .json({ error: "Greška prilikom dobijanja grada iz baze podataka." });
  }
});

// Endpoint za dodavanje novog grada
app.post("/cities", async (req, res) => {
  const city = req.body;
  try {
    const cityId = await db.addCity(city);
    res.status(201).json({ id: cityId });
  } catch (error) {
    console.error("Greška prilikom dodavanja grada u bazu podataka:", error);
    res
      .status(500)
      .json({ error: "Greška prilikom dodavanja grada u bazu podataka." });
  }
});

// Endpoint za ažuriranje postojećeg grada
app.put("/cities/:id", async (req, res) => {
  const cityId = parseInt(req.params.id);
  const cityData = req.body;
  try {
    const updated = await db.updateCity(cityId, cityData);
    if (updated) {
      res.json({ message: "Grad je uspešno ažuriran." });
    } else {
      res.status(404).json({ error: "Grad nije pronađen." });
    }
  } catch (error) {
    console.error("Greška prilikom ažuriranja grada u bazi podataka:", error);
    res
      .status(500)
      .json({ error: "Greška prilikom ažuriranja grada u bazi podataka." });
  }
});

// Endpoint za brisanje grada
app.delete("/cities/:id", async (req, res) => {
  const cityId = parseInt(req.params.id);
  try {
    const deleted = await db.deleteCity(cityId);
    if (deleted) {
      res.json({ message: "Grad je uspešno obrisan." });
    } else {
      res.status(404).json({ error: "Grad nije pronađen." });
    }
  } catch (error) {
    console.error("Greška prilikom brisanja grada iz baze podataka:", error);
    res
      .status(500)
      .json({ error: "Greška prilikom brisanja grada iz baze podataka." });
  }
});

// Pokretanje servera
app.listen(PORT, () => {
  console.log(`Server je pokrenut na portu ${PORT}`);
});
*/
