/// <binding BeforeBuild='css, min:js' Clean='clean' ProjectOpened='watch' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    sass = require("gulp-sass"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    rename = require('gulp-rename'),
    request = require('request'),
    source = require('vinyl-source-stream'),
    fs = require('fs'),
    colors = require('colors'),
    exec = require('child_process').exec;

// paths
var paths = {
     webroot: "./wwwroot/",
     sass: "./wwwroot/assets/sass/**/*.scss",
     cssDest: "./wwwroot/assets/stylesheets"
};


gulp.task('css', function () {
    return gulp.src(paths.sass)
        .pipe(sass())
        .on('error', function (err) {
            console.log('There was an error processing the sass files'.underline.red);
            console.log(colors.cyan(err.toString()));
        })
        .pipe(cssmin())
        .pipe(rename({
            suffix: '.min'
        }))
        .pipe(gulp.dest(paths.cssDest))
        .on('end', function () { console.log('Successfully processed the sass files to css'.bold.yellow); });
});

//watch
gulp.task('watch', function () {
    gulp.watch(paths.sass, ['css']);
});

gulp.task('default', ['watch'])