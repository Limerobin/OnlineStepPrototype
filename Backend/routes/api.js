var express = require("express");
var pageRouter = require("./pages");
var chapterRouter = require("./chapters");
var chapterPagesRouter = require("./chaptersPages");

var app = express();

app.use("/pages/", pageRouter);
app.use("/chapters/", chapterRouter);
app.use("/chapters/pages/", chapterPagesRouter);

module.exports = app;