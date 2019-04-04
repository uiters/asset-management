/// <binding BeforeBuild='build:dev' />
"use strict";

var gulp = require("gulp"),
    merge = require("merge-stream"),
    rimraf = require("rimraf"),
    bundleconfig = require("./package-mapping-config.js");

var regex = {
    css: /\.css$/,
    js: /\.js$/
};

gulp.task('copy:node_modules', function () {
    rimraf.sync(bundleconfig.libsFolder + '/**/*', { force: true });
    var tasks = [];

    for (var mapping in bundleconfig.mappings) {
        if (bundleconfig.mappings.hasOwnProperty(mapping)) {
            var destination = bundleconfig.libsFolder + '/' + bundleconfig.mappings[mapping];
            if (mapping.match(/[^/]+(css|js)$/)) {
                tasks.push(
                    gulp.src(mapping).pipe(gulp.dest(destination))
                );
            } else {
                tasks.push(
                    gulp.src(mapping + '/**/*').pipe(gulp.dest(destination))
                );
            }
        }
    }

    return merge(tasks);
});

function getBundles(regexPattern) {
    return bundleconfig.bundles.filter(function (bundle) {
        return regexPattern.test(bundle.outputFileName);
    });
}

function getOutputFileName(fullFilePath) {
    var lastIndexOfSlash = fullFilePath.lastIndexOf('/');
    return fullFilePath.substr(lastIndexOfSlash, fullFilePath.length - lastIndexOfSlash);
}

function getOutputFolder(fullFilePath) {
    var lastIndexOfSlash = fullFilePath.lastIndexOf('/');
    return fullFilePath.substr(0, lastIndexOfSlash);
}