$(function () {
    console.log("loaded");
});

// For the submitting the note from a learning outcome
function submit_learning_outcome_note(e, textAreaID, learningOutcomeID) {
    
    e.preventDefault();  // Important to override default page refresh

    $.ajax({
        method: "POST",
        data: { note: $(textAreaID).val(), learningOutcomeID: learningOutcomeID },
        url: "/Instructor/Course/ChangeLearningOutcomeNote"   // NOTE: This will need to be different depending on who is editing the note
    }).done(function (result) {
        console.log("action taken: " + result);
        $(textAreaID).val(result.note);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("Failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    }).always(function () {
    });
}



// Code for submitting the note for a course
function submit_course_note(e, courseNoteTextAreaID, courseID) {

    e.preventDefault();  // Important to override default page refresh

    $.ajax({
        method: "POST",
        data: { note: $(courseNoteTextAreaID).val(), courseID: courseID },
        url: "/Instructor/Course/ChangeCourseNote"   // NOTE: This will need to be different depending on who is editing the note
    }).done(function (result) {
        console.log("action taken: " + result);
        $(courseNoteTextAreaID).val(result.note);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log("Failed: ");
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    }).always(function () {
    });
}
