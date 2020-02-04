// Mongoose Models
const Page = require("../models/PageModel");
const Cloze = require("../models/ClozeModel");
const Mcq = require("../models/McqModel");

// Middlewares that wraps validator.js validator and sanitizer functions.
const { body, validationResult } = require("express-validator");
const { sanitizeBody } = require("express-validator");

const apiResponse = require("../helpers/apiResponse");
var mongoose = require("mongoose");

// Page Schema
function PageData(data) {
    this.type = data.type;
    this.title = data.title;
    this.author = data.author;
    this.content = data.content;
}

// Sub Schema
function SubSchema(subType, data) {

    switch (subType) {
        case "mcq":
            return new Mcq(
                {
                    question: data.question,
                    answers: data.answers,
                    correctAnswer: data.correctAnswer
                });
        case "cloze":
            body("type", "Type must not be empty.").isLength({ min: 1 }).trim();
            body("title", "Title must not be empty.").isLength({ min: 1 }).trim();
            return new Cloze(
                {
                    sentence: data.sentence,
                    missingWords: data.missingWords
                });
        default:
    }

}


exports.getPageList = [
    function(req, res) {
        try {
            Page.find({}, "content").then((page) => {
                if (page.length > 0) {
                    return apiResponse.successResponseWithData(res, "Operation success", page);
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

exports.getPage = [
    function (req, res) {
        //if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
        //    return apiResponse.successResponseWithData(res, "Operation success", {});
        //}
        try {
            Page.findOne({ _id: req.params.id }).then((page) => {
                if (Page !== null) {
                    let pageData = new PageData(Page);
                    return apiResponse.successResponseOnlyJSONObject(res, page);
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


exports.addPage = [
    body("type", "Type must not be empty.").isLength({ min: 1 }).trim(),
    body("title", "Title must not be empty.").isLength({ min: 1 }).trim(),
    body("author", "Author must not be empty").isLength({ min: 1 }).trim(),
    //,
    //sanitizeBody("*").escape(),
    (req, res) => {
        try {
           
            const errors = validationResult(req);
            var subSchema = SubSchema(req.body.type, req.body.content);

            var page = new Page(
                {
                    type: req.body.type,
                    title: req.body.title,
                    author: req.body.author,
                    content: subSchema
                });

            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                //Save Question.
                page.save(function (err) {
                    if (err) { return apiResponse.ErrorResponse(res, err); }
                    let pageData = new PageData(page);
                    return apiResponse.successResponseWithData(res, "Page add Successfully.", pageData);
                });
            }
        } catch (err) {
            //throw error in json response with status 500. 
            return apiResponse.ErrorResponse(res, err);
        }
    }
];

exports.updatePage = [
    (req, res) => {
        try {
            const errors = validationResult(req);
            var subSchema = SubSchema(req.body.type, req.body.content);

            var page = new Page(
                {
                    _id: req.params.id,
                    type: req.body.type,
                    title: req.body.title,
                    author: req.body.author,
                    content: subSchema
                });

            if (!errors.isEmpty()) {
                return apiResponse.validationErrorWithData(res, "Validation Error.", errors.array());
            }
            else {
                if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
                    return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
                } else {
                    Page.findById(req.params.id, function (err, foundPage) {
                        if (foundPage === null) {
                            return apiResponse.notFoundResponse(res, "Page not exists with this id");
                        }  else {
                                //update page.
                                Page.findByIdAndUpdate(req.params.id, page, {}, function (err) {
                                    if (err) {
                                        return apiResponse.ErrorResponse(res, err);
                                    } else {
                                        let pageData = new PageData(page);
                                        return apiResponse.successResponseWithData(res, "Page update Success.", pageData);
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

exports.deletePage = [
    function (req, res) {
        if (!mongoose.Types.ObjectId.isValid(req.params.id)) {
            return apiResponse.validationErrorWithData(res, "Invalid Error.", "Invalid ID");
        }
        try {
            Page.findById(req.params.id, function (err, foundPage) {
                if (foundPage === null) {
                    return apiResponse.notFoundResponse(res, "Page not exists with this id");
                } else  {
                        //delete page.
                        Page.findByIdAndRemove(req.params.id, function (err) {
                            if (err) {
                                return apiResponse.ErrorResponse(res, err);
                            } else {
                                return apiResponse.successResponse(res, "Page delete Success.");
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