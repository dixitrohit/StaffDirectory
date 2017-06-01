//This controller is used for Staff operations such as Listing/Add/Edit
(function () {
    var app = angular.module("StaffDirectoryApp", ['ngResource']);

    //Fetch Staff directory data
    app.controller("StaffDirectoryController", function ($resource) {
        var s = $resource('http://localhost:61046/api/Staff');
        var vm = this;
        s.query(function (data) {
            vm.StaffListing = data;
        });
        
    });

    // Add/Edit Staff member
    app.controller("StaffEditController", StaffEditController)
    
    function StaffEditController($resource) {
        var vm = this;
        vm.staff = {};
        var User = $resource('http://localhost:61046/api/Staff/:id', { id: '@id' });
        var user = User.get({ id: 1 }, function (data) {
            vm.staff = data;
            vm.originalStaff = angular.copy(data);
        });

        vm.submit = function () {
            vm.message = '';
            if (vm.staff.StaffID)
            {
                UpdateStaff.update(vm.staff);
            }
            else 
            {
                vm.staff.$save(function (data) {
                    vm.originalStaff = angular.copy(data);
                    vm.message = "Save Complete";
                });
            }
        }

        var UpdateStaff = $resource('http://localhost:61046/api/Staff/:id',
                                     { id: '1' },
                                     { 'update': { method: 'PUT' } },
                                     function (data) {
                                         vm.message = "Save Complete."
                                     });
        vm.staff = UpdateStaff.get();

        vm.cancel = function (editform) {
            editform.$setPristine();
            vm.staff = angular.copy(vm.originalStaff);
            vm.message = "";
        };
        
        vm.reset = function (editform) {
            editform.$setPristine();
            vm.staff = {};
            vm.message = "";
        };
        
    };
}());