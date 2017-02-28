//引入插件
var gulp = require('gulp'),
    less = require('gulp-less');

gulp.task('less', function () {
    return gulp.src('src/less/*.less')
        .pipe(less())
        .pipe(gulp.dest('dist/css'))
})

gulp.task('default', ['watch'], function () {
    gulp.start('less');
});

// 监听
gulp.task('watch', function () {
    gulp.watch('src/less/*.less', ['less']);
});