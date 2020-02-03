var express = require("express");
var userRouter = require("./users");
var pageRouter = require("./pages");
var MissingWordRouter = require("./pages/missing-words");

var app = express();

app.use("/users/", userRouter);
app.use("/pages/", pageRouter);
app.use("/pages/missing-words", MissingWordRouter);

module.exports = app;