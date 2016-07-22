var gulp = require('gulp');
var concat = require('gulp-concat');
var angualarFileSort = require('gulp-angular-filesort');
var strip = require('gulp-strip-line');
var templateCache = require('gulp-angular-templatecache');

gulp.task('buildMenuTemplateCache', function () {
    return gulp.src(['./ext-modules/dmMenu/**/*.html'
    ])
        .pipe(templateCache({
            root: 'ext-modules/dmMenu',
            module:'dmMenu'
        })).pipe(gulp.dest('./ext-modules/dmMenu'));
});

gulp.task('buildFrameworkTemplateCache', function () {
    return gulp.src(['./ext-modules/dmFramework/**/*.html'
    ])
         .pipe(templateCache({
             root: 'ext-modules/dmFramework',
             module: 'dmFramework'
         })).pipe(gulp.dest('./ext-modules/dmFramework'));
});

gulp.task('buildDashboardTemplateCache', function () {
    return gulp.src(['./ext-modules/dmDashboard/**/*.html'
    ])
         .pipe(templateCache({
             root: 'ext-modules/dmDashboard',
             module: 'dmDashboard'
         })).pipe(gulp.dest('./ext-modules/dmDashboard'));
});

gulp.task('buildJavaScript', function () {
    return gulp.src(['./ext-modules/**/*.js'])
          .pipe(angualarFileSort())
          .pipe(strip(['use strict']))
          .pipe(concat('dmFramework.js'))
          .pipe(gulp.dest('./dist/'));
});

gulp.task('buildCSS', function () {
    return gulp.src(['./ext-modules/**/*.css'])
            .pipe(concat('dmFramework.css'))
            .pipe(gulp.dest('./dist/'));
});
