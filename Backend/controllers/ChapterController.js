// Mongoose Models
const Chapter = require("../models/ChapterModel");

// Middlewares that wraps validator.js validator and sanitizer functions.
const { body, validationResult } = require("express-validator");
const { sanitizeBody } = require("express-validator");

const apiResponse = require("../helpers/apiResponse");
var mongoose = require("mongoose");

// Chapter Schema
function ChapterData(data) {
    this.name = data.name;
    this.author = data.author;
    this.subjects = data.subjects;
    this.pages = data.pages;
}

exports.getChapterList = [
    function (req, res) {
        try {
            Chapter.find({}, "content").then((chapter) => {
                if (chapter.length > 0) {
                    return apiResponse.successResponseWithData(res, "Operation success", chapter);
                } else {
                    return apiResponse.successResponseWithData(res, "Operation success", []);
                }
            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.getChapter = [
    function (req, res) {
        //if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
        //    return apiResponse.successResponseWithData(res, "Operation success", {});
        //}
        try {
            Chapter.findOne({ _id: req.params.id }, "_id type title author").then((chapter) => {
                if (Chapter !== null) {
                    let chapterData = new ChapterData(Chapter);
                    return apiResponse.successResponseWithData(res, "Operation success.", chapter);
                } else {
                    return apiResponse.successResponseWithData(res, "Operation success", {});
                }
            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];


exports.addChapter = [
    //body("type", "Type must not be empty.").isLength({ min: 1 }).trim(),
    //body("title", "Title must not be empty.").isLength({ min: 1 }).trim(),
    //body("author", "Author must not be empty").isLength({ min: 1 }).trim()
    //,
    //sanitizeBody("*").escape(),
    (req, res) => {
        try {

            const errors = validationResult(req);

            var chapter = new Chapter(
                {
                    name: req.body.name,
                    author: req.body.author,
                    subjects: req.body.subjects,
                    pages: req.body.pages
                });

            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                //Save Question.
                chapter.save(function (err) {
                    if (err) { return apiResponse.ErrorResponse(res, err); }
                    let chapterData = new Chapter(chapter);
                    return apiResponse.successResponseWithData(res, "Chapter add Successfully.", chapterData);
                });
            }
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.updateChapter = [
    //body("type", "Type must not be empty.").isLength({ min: 1 }).trim(),
    //body("title", "Title must not be empty.").isLength({ min: 1 }).trim(),
    //body("author", "Author must not be empty").isLength({ min: 1 }).trim()
    //,
    //sanitizeBody("*").escape(),
    (req, res) => {

        console.log("Hej på dig");
        console.log(req.params.id);
        console.log('Body');
        console.log(req.body);
        try {
            const errors = validationResult(req);
            var chapter = new Chapter(
                {
                    name: req.body.name,
                    author: req.body.author,
                    subjects: req.body.subjects,
                    pages: req.body.pages
                });

            console.log('chapter');
            console.log(chapter);

            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
                    return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
                } else {
                    Chapter.findById(req.params.id, function (err, foundChapter) {
                        if (foundChapter === null) {
                            return apiResponse.notFoundResponse(res, "Chapter not exists with this id");
                        } else {
                            //update chapter.
                            Chapter.findByIdAndUpdate(req.params.id, chapter, {}, function (err) {
                                if (err) {
                                    return apiResponse.ErrorResponse(res, err);
                                } else {
                                    let chapterData = new ChapterData(chapter);
                                    return apiResponse.successResponseWithData(res, "Chapter update Success.", chapterData);
                                }
                            });
                        }

                    });
                }
            }
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.deleteChapter = [
    function (req, res) {
        if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
            return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
        }
        try {
            Chapter.findById(req.params.id, function (err, foundChapter) {
                if (foundChapter === null) {
                    return apiResponse.notFoundResponse(res, "Chapter not exists with this id");
                } else {
                    //delete chapter.
                    Chapter.findByIdAndRemove(req.params.id, function (err) {
                        if (err) {
                            return apiResponse.ErrorResponse(res, err);
                        } else {
                            return apiResponse.successResponse(res, "Chapter delete Success.");
                        }
                    });
                }

            });
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];