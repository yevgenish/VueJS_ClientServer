<template>
    <div>
        <h1>Employees:</h1>
        <input type="button" value="Get Employees" @click="getEmployeesFromServer" />
        <br />
        <div class="error">{{error}}</div>
        <div class="employees">
            <div class="employee" v-for="employee in employees" v-bind:key="employee.EmployeeId">
                <ul>
                    <li v-for="(value, key) in employee" v-bind:key="key">
                        {{value}}
                    </li>
                    <li><input type="button" value="Select" @click="employeeSelected(employee.EmployeeId)" /></li>
                </ul>
            </div>
        </div>
        <br />
        <div class="controls">
            <input type="button" value="Add New" @click="employeeSelected(0)" /> 
        </div>
        
    </div>
</template>
<script>

import serverData from '../services/serverData';
import { serverBus } from '../main';

export default {
    /*name:'employeesList',*/
    data: function(){
        return {
            employees: [],
            error:''
        }
    },
    created(){
        this.getEmployeesFromServer();

        serverBus.$on('employeesUpdated', () => {
            //debugger;
            this.getEmployeesFromServer();
        });
    },
    methods: {
        getEmployeesFromServer(){
            serverData.getEmployees().then((c)=>{
                this.employees=c.body;
            }).catch((c)=>{
                this.error = c;
            });
        },
        employeeSelected(id){
            //debugger;
            //using serverBus
            //alert(this);
            if(!(id >= 0)){
                return;
            }

            var currentEmployee = null;
            if(id == 0){
                currentEmployee = {
                    EmployeeId: 0,
                    EmployeeName: '',
                    Address: '',
                    Department: ''                
                };
            }else{
                for(var i = 0; i < this.employees.length; i++){
                    if(this.employees[i].EmployeeId == id){
                        currentEmployee = JSON.parse(JSON.stringify(this.employees[i]));
                        //currentEmployee = this.employees[i];
                        break;
                    }
                }
            }

            serverBus.$emit('employeeSelected', currentEmployee);
        }
    }
}
</script>
<style>
    .error{
        color: red;
    }

    .employees{
        /*text-align: center;*/
        display: inline-block;
    }

    .employee{
        background-color: aquamarine;
    }

    div.employee ul {
        list-style-type: none;
        padding: 0;
        width: 600px;
        display: table;
        table-layout: fixed;
    }

    div.employee ul li {
        margin: 0 10px;
        display: table-cell;
    }


</style>



