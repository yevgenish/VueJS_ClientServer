<template>
    <div>
        <p class="messages">
            <span class="error">{{error}}</span>
            <span class="message">{{result}}</span>
        </p>
        <div v-if="employee != null">
            <input type="hidden" id="hiddenEmployeeId" v-model="employee.EmployeeId" />
            <div class="fields">
                <label>
                    <ul>
                        <li>
                            <span>Employee Name</span>
                        </li>
                        <li>
                            <input type="text" v-model="employee.EmployeeName"
                            @focus="validateForm().employeeName_Changed()" />
                        </li>
                        <li>
                            <span v-show="validate.employeeNameValidator_Visible" class="validator">*</span>
                        </li>
                    </ul>
                </label>
                <label>
                    <ul>
                        <li>                    
                            <span>Address</span>                    
                        </li>
                        <li>
                            <input type="text" v-model="employee.Address"
                            @focus="validateForm().address_Changed()" />
                        </li>
                        <li>
                            <span v-show="validate.addressValidator_Visible" class="validator">*</span>
                        </li>
                    </ul>
                </label>
                <label>
                    <ul>
                        <li>
                            <span>Department</span>                   
                        </li>
                        <li>
                            <input type="text" v-model="employee.Department"
                            @focus="validateForm().department_Changed()" />
                        </li>
                        <li>
                            <span v-show="validate.departmentValidator_Visible" class="validator">*</span>
                        </li>
                    </ul>
                </label>
            </div>
            <br />
            <div class="controls">
                <input type="button" value="Add Employee" @click="addEmployee" />
                <input type="button" value="Update Employee" @click="updateEmployee" v-show="employee.EmployeeId > 0" />
                <input type="button" value="Delete Employee" @click="deleteEmployee" v-show="employee.EmployeeId > 0" />
                <input type="button" value="Cancel" @click="cancelChange" />
            </div>
        </div>
        <br />
    </div>
</template>
<script>
import serverData from '../services/serverData';
import validator from '../helpers/validator';

import { serverBus } from '../main';

export default {
    data: function(){
        return {
            /*
            employee: {
                EmployeeId: '',
                EmployeeName: '',
                Address: '',
                Department: ''
                    },*/
            employee: null,
            error: '',
            result: '',
            validate:{
                employeeNameValidator_Visible: false,
                addressValidator_Visible: false,
                departmentValidator_Visible: false
            },
            serverResultMessage:{
                error: 'Error occured. Please try again later.',
                success: 'Done'
            }
        };
    },
    created(){

        serverBus.$on('employeeSelected', (employee) => {
            //debugger;
            this.employee = employee;

            this.validate.employeeNameValidator_Visible = false;
            this.validate.addressValidator_Visible = false;
            this.validate.departmentValidator_Visible = false;
            
        });
    },
    //beforeDestroy (){
        //debugger;
        //this.employee = null;
        //alert('destroy: ' + this.employee);
    //},
    methods:{
        getEmployee(id){
            if(!(id > 0)){
                return;
            }

            serverData.getEmployee(id).then((c)=>{
                this.employee = c.body;
            }).catch((c)=>{
                //this.error = (c && c.statusText) || this.serverResultMessage.error;
                this.error = this.serverResultMessage.error;

                var this2 = this;
                setTimeout(function(){       
                    this2.error = '';                                       
                }, 5000);
            });
        },
        addEmployee(){
            //debugger;
            if(this.employee == null){
                return;
            }

            var isValid = this.validateForm().validateInputFields();
            if(!isValid)
                return;

            var employee = {
                EmployeeName: this.employee.EmployeeName,
                Address: this.employee.Address,
                Department: this.employee.Department                
            };

            serverData.addEmployee(employee).then((c)=>{
                this.result = this.serverResultMessage.success;//c.body;     

                this.employee = null;
                //notify about changes
                serverBus.$emit('employeesUpdated');

                var this2 = this;
                setTimeout(function(){
                    //debugger;
                    this2.result = '';
                                       
                }, 2000);

            }).catch((c)=>{
                //this.error = (c && c.statusText) || this.serverResultMessage.error;
                this.error = this.serverResultMessage.error;

                var this2 = this;
                setTimeout(function(){       
                    this2.error = '';                                       
                }, 5000);
            });
        },
        updateEmployee(){
            //debugger;
            if(this.employee == null || !(this.employee.EmployeeId > 0)){
                return;
            }

            var isValid = this.validateForm().validateInputFields();
            if(!isValid)
                return;

            var employee = {
                EmployeeId: this.employee.EmployeeId,
                EmployeeName: this.employee.EmployeeName,
                Address: this.employee.Address,
                Department: this.employee.Department                
            };

            serverData.updateEmployee(employee).then((c)=>{
                this.result = this.serverResultMessage.success;//c.body;

                this.employee = null;
                //notify about changes   
                serverBus.$emit('employeesUpdated');
                  
                var this2 = this;
                setTimeout(function(){
                    //debugger;
                    this2.result = '';               
                }, 2000);

            }).catch((c)=>{
                //this.error = (c && c.statusText) || this.serverResultMessage.error;
                this.error = this.serverResultMessage.error;

                var this2 = this;
                setTimeout(function(){       
                    this2.error = '';                                       
                }, 5000);
            });
        },
        deleteEmployee(){
            //debugger;
            if(this.employee == null || !(this.employee.EmployeeId > 0)){
                return;
            }

            var isValid = this.validateForm().validateInputFields();
            if(!isValid)
                return;

            var employeeId = this.employee.EmployeeId;

            serverData.deleteEmployee(employeeId).then((c)=>{
                this.result = this.serverResultMessage.success;//c.body;

                this.employee = null;

                //notify about changes
                serverBus.$emit('employeesUpdated');

                var this2 = this;
                setTimeout(function(){
                    //debugger;
                    this2.result = ''; 
                }, 2000);

            }).catch((c)=>{
                //this.error = (c && c.statusText) || this.serverResultMessage.error;
                this.error = this.serverResultMessage.error;

                var this2 = this;
                setTimeout(function(){       
                    this2.error = '';                                       
                }, 5000);
            });
        },
        cancelChange(){
            //debugger;
            //this.$destroy();
            this.employee = null;
        },
        validateForm(){
            var self = this;
            function validateInputFields(){
                var isValid = false;
                var employeeName_IsValid = validator.hasValue(self.employee.EmployeeName);            
                var address_IsValid = validator.hasValue(self.employee.Address); 
                var department_IsValid = validator.hasValue(self.employee.Department); 

                if(!employeeName_IsValid){                            
                    self.validate.employeeNameValidator_Visible = true;            
                }
                if(!address_IsValid){
                    self.validate.addressValidator_Visible = true;
                }
                if(!department_IsValid){
                    self.validate.departmentValidator_Visible = true;
                }

                isValid = employeeName_IsValid && address_IsValid && department_IsValid;

                return isValid;
            }

            function employeeName_Changed(){
                //debugger;
                self.validate.employeeNameValidator_Visible = false;
            }
            function address_Changed(){
                //debugger;
                self.validate.addressValidator_Visible = false;
            }
            function department_Changed(){
                //debugger;
                self.validate.departmentValidator_Visible = false;
            }

            return {
                validateInputFields,
                employeeName_Changed,
                address_Changed,
                department_Changed
            }
        }
    }
}
</script>
<style>

div.fields{
    display: inline-block;
}

div.fields ul {
  list-style-type: none;
  padding: 0;
  width: 380px;
  display: table;
  table-layout: fixed; 
}

div.fields ul li {
  margin: 0 10px;
  display: table-cell;
  flex: 0 0 50%;
}
div.fields ul li:first-child {
    text-align: left;
}

div.fields ul li:last-child {
    width: 30px;
}


</style>


