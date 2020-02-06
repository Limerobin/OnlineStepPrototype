var mongoose = require("mongoose");
var Schema = mongoose.Schema;

var ClozeSchema = new Schema(
    {
        sentence: { type: String, required: true },
        missingWords: { type: [String], required: true }
    },
    {
        _id: false
    }
);

module.exports = mongoose.model("cloze", ClozeSchema);
