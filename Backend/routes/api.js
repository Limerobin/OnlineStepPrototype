var express = require("express");
var pageRouter = require("./pages");
var chapterRouter = require("./chapters");

var app = express();

app.use("/pages/", pageRouter);
app.use("/chapters/", chapterRouter);

module.exports = app;