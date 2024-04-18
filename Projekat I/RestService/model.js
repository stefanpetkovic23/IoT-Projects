/*const { DataTypes, Sequelize } = require("sequelize");

// Povezivanje sa bazom podataka
const sequelize = new Sequelize("smart_cities", "root", "root", {
  host: "localhost",
  dialect: "mysql",
});

// Definicija modela
const City = sequelize.define("City", {
  city: { type: DataTypes.STRING, allowNull: false },
  country: { type: DataTypes.STRING, allowNull: false },
  smartMobility: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartEnvironment: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartGovernment: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartEconomy: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartPeople: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartLiving: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartCityIndex: { type: DataTypes.FLOAT, defaultValue: 0 },
  smartCityIndexRelativeEdmonton: { type: DataTypes.FLOAT, defaultValue: 0 },
});

// Synchronizacija modela sa bazom podataka
sequelize.sync();

module.exports = City; */
