/// <reference path="~Scripts/angular.js" />
var myApp = angular
    .module("myModule", [])
    .controller("myController", function ($scope) {
        var technologies = [
            { name: "C#", likes: 0, dislikes: 0 },
            { name: "ASP.NET", likes: 0, dislikes: 0},
            { name: "Sql Servier", likes: 0, dislikes: 0 },
            { name: "Java", likes: 0, dislikes: 0 },
            { name: "AngularJS", likes: 0, dislikes: 0 }
        ]


        $scope.technologies = technologies;

        $scope.incrementLikes = function (tech) {
            tech.likes++;
        }

        $scope.incrementDislikes = function (tech) {
            tech.dislikes++;
        }
    });