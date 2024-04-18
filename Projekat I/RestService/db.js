/*const mysql = require("mysql");

// Konfiguracija za konekciju
const connection = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "root",
  database: "smart_cities",
});

connection.connect((err) => {
  if (err) {
    console.error("Greška prilikom konektovanja na bazu:", err);
    return;
  }
  console.log("Konektovano na MySQL bazu podataka.");
});

// Funkcija za dohvatanje svih gradova
async function getAllCities() {
  return new Promise((resolve, reject) => {
    connection.query("SELECT * FROM SmartCities", (error, results) => {
      if (error) {
        reject(error);
        return;
      }
      resolve(results);
    });
  });
}

// Funkcija za dohvatanje grada po ID-u
async function getCityById(cityId) {
  return new Promise((resolve, reject) => {
    connection.query(
      "SELECT * FROM SmartCities WHERE Id = ?",
      [cityId],
      (error, results) => {
        if (error) {
          reject(error);
          return;
        }
        if (results.length === 0) {
          resolve(null); // Grad nije pronađen
        } else {
          resolve(results[0]);
        }
      }
    );
  });
}

// Funkcija za dodavanje novog grada
async function addCity(city) {
  return new Promise((resolve, reject) => {
    connection.query(
      "INSERT INTO SmartCities SET ?",
      city,
      (error, results) => {
        if (error) {
          reject(error);
          return;
        }
        resolve(results.insertId);
      }
    );
  });
}

// Funkcija za ažuriranje postojećeg grada
async function updateCity(cityId, cityData) {
  return new Promise((resolve, reject) => {
    connection.query(
      "UPDATE SmartCities SET ? WHERE Id = ?",
      [cityData, cityId],
      (error, results) => {
        if (error) {
          reject(error);
          return;
        }
        if (results.affectedRows === 0) {
          resolve(false); // Grad nije pronađen
        } else {
          resolve(true);
        }
      }
    );
  });
}

// Funkcija za brisanje grada
async function deleteCity(cityId) {
  return new Promise((resolve, reject) => {
    connection.query(
      "DELETE FROM SmartCities WHERE Id = ?",
      [cityId],
      (error, results) => {
        if (error) {
          reject(error);
          return;
        }
        resolve(results.affectedRows > 0);
      }
    );
  });
}

module.exports = {
  getAllCities,
  getCityById,
  addCity,
  updateCity,
  deleteCity,
};
*/
