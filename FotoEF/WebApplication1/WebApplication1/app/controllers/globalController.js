(function () {
    'use strict';

    var moduleId = 'app';
    var controllerId = 'globalController';

    angular.module(moduleId).controller(controllerId, globalController);

    globalController.$inject = ['$scope', '$rootScope', '$state', '$http', '$location','$window'];

    function globalController($scope, $rootScope, $state, $http, $location, $window) {

        //variables
        var vm = this;

        vm.folder = {
            id: '',
            name: '',
            description: '',
            icon: ''
        };
        vm.file1 = {
            id: '',
            name: '',
            description: '',
            id_folder: ''
        };

        vm.folderList = {
            id: 'folderList',
            items: [],
            isEdit : false,
            //selectedItem: undefined,
            //isLoading: false,
            getItems: function () {
                $http({
                    method: 'GET',
                    url: $location.protocol() + '://' + $location.host() + ($location.port() === '80' ? '' : ':' + $location.port()) + '/api/FolderMgt/get',
                    headers: { 'Content-Type': 'application/json' },
                    params: {},
                    data: {}
                }).then(
                    function onSuccess(response) {
                        var data = response.data;
                        var status = response.status;
                        var statusText = response.statusText;
                        var headers = response.headers;
                        var config = response.config;

                        vm.folderList.items = data.items;
                    },
                    function onError(response) {
                        // Handle error
                        var data = response.data;
                        var status = response.status;
                        var statusText = response.statusText;
                        var headers = response.headers;
                        var config = response.config;
                    }
                    );
            },
            //onSelected: function (item) {
            //    this.selectedItem = angular.copy(item);
            //    vm.User.userIdRole = item.idRole;
            //    vm.folderList.selectedItem = item;
            //},
            //onSuccess: function (data, status, headers, config) {
            //    if (data.items.length > 0) {
            //        vm.folderList.selectedItem = angular.copy(data.items[0]);
            //    }
            //    vm.folderList.items = data.items;
            //    //vm.folderList.isLoading = false;
            //},
            onError: function (data, status, headers, config) {
                _errorHttp(data, status, headers, config);
                //vm.folderList.isLoading = false;
            },
            addFolder: function () {
                if (vm.folder.name != '' && vm.folder.name != null && this.isEdit == false) {
                    $http({
                        method: 'POST',
                        url: $location.protocol() + '://' + $location.host() + ($location.port() == '80' ? '' : ':' + $location.port()) + '/api/FolderMgt/post',
                        headers: { 'Content-Type': 'application/json' },
                        data: vm.folder
                    }).then(
                        function onSuccess(response) {
                            var data = response.data;
                            var status = response.status;
                            var statusText = response.statusText;
                            var headers = response.headers;
                            var config = response.config;

                            if (data != '-1') {
                                if (status == '200') {
                                    vm.folderList.getItems();
                                    vm.folderList.clearFolder();
                                }

                            }
                            else if (data == '-1') {
                                return false;
                            }
                        },
                        function onError(response) {
                            // Handle error
                            var data = response.data;
                            var status = response.status;
                            var statusText = response.statusText;
                            var headers = response.headers;
                            var config = response.config;
                        }
                    );
                } else
                    if (vm.folder.name != '' && vm.folder.name != null && this.isEdit == true)
                    {
                        $http({
                            method: 'PUT',
                            url: $location.protocol() + '://' + $location.host() + ($location.port() == '80' ? '' : ':' + $location.port()) + '/api/FolderMgt/put',
                            headers: { 'Content-Type': 'application/json' },
                            data: vm.folder
                        }).then(
                            function onSuccess(response) {
                                var data = response.data;
                                var status = response.status;
                                var statusText = response.statusText;
                                var headers = response.headers;
                                var config = response.config;

                                if (data != '-1') {
                                    if (status == '200') {
                                        vm.folderList.getItems();
                                        vm.folderList.clearFolder();
                                        this.isEdit == false;
                                    }

                                }
                                else if (data == '-1') {
                                    return false;
                                }
                            },
                            function onError(response) {
                                // Handle error
                                var data = response.data;
                                var status = response.status;
                                var statusText = response.statusText;
                                var headers = response.headers;
                                var config = response.config;
                            }
                            );
                       
                    }

                else {
                    if (vm.folder.name != '' || vm.folder.name != null)
                        $window.alert("Please enter value - Name of folder!");
                }
            },
            editFolder: function (row) {
                if (row != undefined) {
                    vm.folder.id = row.id;
                    vm.folder.name = row.name;
                    vm.folder.description = row.description;
                    vm.folder.icon = row.icon;
                    this.isEdit = true;
                } else {
                    this.clearFolder();
                    this.isEdit = false;

                }
            },
            deleteFolder: function (row) {
                var isConfirmed = confirm("Are you sure to delete this record ?");
                if (isConfirmed) {
                    //if (vm.folder.name != '' && vm.folder.name != null) {
                        $http({
                            method: 'DELETE',
                            url: $location.protocol() + '://' + $location.host() + ($location.port() == '80' ? '' : ':' + $location.port()) + '/api/FolderMgt/delete',
                            headers: { 'Content-Type': 'application/json' },
                            data: row
                        }).then(
                            function onSuccess(response) {
                                var data = response.data;
                                var status = response.status;
                                var statusText = response.statusText;
                                var headers = response.headers;
                                var config = response.config;

                                if (data != '-1') {
                                    if (status == '200') {
                                        vm.folderList.getItems();
                                        this.clearFolder();
                                    }
                                }
                                else if (data == '-1') {
                                    return false;
                                }
                            },
                            function onError(response) {
                                // Handle error
                                var data = response.data;
                                var status = response.status;
                                var statusText = response.statusText;
                                var headers = response.headers;
                                var config = response.config;
                            }
                            );

                    //}
                }
            },
            clearFolder: function () {
                vm.folder.id = '';
                vm.folder.name = '';
                vm.folder.description = '';
                vm.folder.icon = '';
            }
        };

        //--------------------------------------------------
        vm.isSubmitting = false;
        vm.isRemoveDisabled = false;

        vm.onSubmit = function () {
            vm.isSubmitting = true;
            uploadFile();
            //uploadFile2();
        };

        vm.onRemove = function () {
            vm.isSubmitting = true;
            removePathToLogoForTP();
        };

        vm.SelectFileLogo1 = function () {
            vm.isRemoveDisabled = document.getElementById('file').value != '' ? true : false;
            vm.isSubmitting = false;
            if (vm.isRemoveDisabled == false) {

            }

        };

        vm.onClear = function () {
            vm.isSubmitting = false;
            vm.result = '';
            document.getElementById('file').value = "";            
        };

        function uploadFile() {
            vm.file = document.getElementById('file').files[0];
            var fd = new FormData();
            fd.append("file", vm.file);
            importFile(fd);
        };

        function importFile(filepath) {

            vm.file1.id_folder = 1;//test
            vm.file1.name = vm.file.name;
            //filepath.append("id_folder", 1);
            //filepath.append("name", vm.file.name);
            //filepath.append("description", vm.file1.description);
            //filepath.append("id", 0);
          
            $http({
                method: 'POST',
                url: $location.protocol() + '://' + $location.host() + ($location.port() == '80' ? '' : ':' + $location.port()) + '/api/FotoFilesMgt/post', 
                data: vm.file1,
                //headers: { 'Content-Type': undefined },                
                headers: { 'Content-Type': 'application/json' },
                //headers: { 'Content-Type': 'multipart/form-data' },
                //transformRequest: angular.identity,
               
            }).then(
                function onSuccess(response) {
                    var data = response.data;
                    var status = response.status;
                    var statusText = response.statusText;
                    var headers = response.headers;
                    var config = response.config;

                    if (data != '-1') {
                        if (status == '200') {
                            
                        }

                    }
                    else if (data == '-1') {
                        return false;
                    }
                },
                function onError(response) {
                    // Handle error
                    var data = response.data;
                    var status = response.status;
                    var statusText = response.statusText;
                    var headers = response.headers;
                    var config = response.config;
                }
            );
            



            document.getElementById('file').value = "";
        }

        function initialize() {
            vm.folderList.getItems();
        }
        initialize();
    }

})();