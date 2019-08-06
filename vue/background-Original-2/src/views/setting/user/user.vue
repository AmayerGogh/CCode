<template>
    <div>
        <el-card class="box-card">            
            <div class="page-body">
                <!-- <Form ref="queryForm" :label-width="80" label-position="left" inline>
                    <Row :gutter="16">
                        <Col span="6">
                            <FormItem :label="L('Keyword')+':'" style="width:100%">
                                <Input v-model="pagerequest.keyword" :placeholder="L('UserName')+'/'+L('Name')"></Input>
                            </FormItem>
                        </Col>
                        <Col span="6">
                            <FormItem :label="L('IsActive')+':'" style="width:100%">                              
                                <Select  :placeholder="L('Select')" @on-change="isActiveChange">
                                    <Option value="All">{{L('All')}}</Option>
                                    <Option value="Actived">{{L('Actived')}}</Option>
                                    <Option value="NoActive">{{L('NoActive')}}</Option>
                                </Select>
                            </FormItem>
                        </Col>
                        <Col span="6">
                            <FormItem :label="L('CreationTime')+':'" style="width:100%">
                                <DatePicker  v-model="creationTime" type="datetimerange" format="yyyy-MM-dd" style="width:100%" placement="bottom-end" :placeholder="L('SelectDate')"></DatePicker>
                            </FormItem>
                        </Col>
                    </Row>
                    <Row>
                        <Button @click="create" icon="android-add" type="primary" size="large">{{L('Add')}}</Button>
                        <Button icon="ios-search" type="primary" size="large" @click="getpage" class="toolbar-btn">{{L('Find')}}</Button>
                    </Row>
                </Form> -->

                <el-form :inline="true" ref="queryForm">
                    <el-row :gutter="16">
                        <el-col :span="6">
                            <el-form-item :label="L('Keyword')+':'">
                                <el-input  v-model="pagerequest.keyword" :placeholder="L('UserName')+'/'+L('Name')"></el-input>
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item :label="L('IsActive')+':'" style="width:100%">                              
                                 <el-select v-model="pagerequest.isActive"   placeholder="请选择">
                                    <el-option
                                    v-for="item in selectList"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-form-item>
                        </el-col>
                        <el-col :span="6">
                            <el-form-item :label="L('CreationTime')+':'" style="width:100%">
                                <el-date-picker  v-model="creationTime" 
                                    type="datetimerange" 
                                    format="yyyy-MM-dd" 
                                    style="width:100%" placement="bottom-end" 
                                    :placeholder="L('SelectDate')">
                                </el-date-picker>
                            </el-form-item>
                        </el-col>
                       
                    
                    </el-row>
                    <el-row>
                       <el-button @click="create" icon="android-add" type="primary" size="large">{{L('Add')}}</el-button>
                       <el-button icon="ios-search" type="primary" size="large" @click="getpage" class="toolbar-btn">{{L('Find')}}</el-button>
                    </el-row>
                   
                </el-form>
                <div class="margin-top-10">
                    <Table :loading="loading" 
                    :columns="columns" 
                    :no-data-text="L('NoDatas')" 
                    border 
                    :data="list">
                    </Table>  

                    <el-table  
                    :data="list" 
                     border
                    style="width:100%">
                        <el-table-column
                            prop="userName"
                            :label="L('UserName')"
                            width="180">
                        </el-table-column>
                        
                        <el-table-column
                            prop="name"
                            :label="L('Name')"
                            >
                        </el-table-column>
                        <el-table-column                           
                            :label="L('IsActive')">
                            <template slot-scope="scope">
                                 {{scope.row.isActive?L('Yes'):L('No')}}
                            </template>    
                        </el-table-column>
                        <el-table-column
                            prop="creationTime"
                            :label="L('CreationTime')"
                           :formatter="formatter"
                            >
                        </el-table-column>
                        <el-table-column
                            prop="lastLoginTime"
                            :label="L('LastLoginTime')"
                            >
                        </el-table-column>
                         <el-table-column
                            fixed="right"
                            label="操作"
                            width="100">
                            <template slot-scope="scope">
                                <el-button @click="handleClick(scope.row)" type="primary" size="mini">编辑</el-button>
                                <el-button @click="handleClick_del(scope.row)" type="danger" size="mini">删除</el-button>
                            </template>
                        </el-table-column>
                    </el-table>

                    <el-pagination
                        background
                        class="margin-top-10" 
                        layout="total, sizes, prev, pager, next, jumper"
                        :page-sizes="[10, 20, 50, 100]"
                        :page-size="10"
                        @current-change="pageChange"
                        :total="totalCount">
                    </el-pagination>
                </div>
            </div>
        </el-card>
        <create-user v-model="createModalShow" @save-success="getpage"></create-user>
        <edit-user v-model="editModalShow" @save-success="getpage"></edit-user>
    </div>
</template>
<script lang="ts">
    import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
    import Util from '@/lib/util'
    import AbpBase from '@/lib/abpbase'
    import PageRequest from '@/store/entities/page-request'
    import CreateUser from './create-user.vue'
    import EditUser from './edit-user.vue'
    class  PageUserRequest extends PageRequest{
        keyword:string;
        isActive:any=null;//nullable
        from:Date;
        to:Date;
    }
    
    @Component({
        components:{CreateUser,EditUser}
    })
    export default class Users extends AbpBase{
        edit(){
            this.editModalShow=true;
        }
        //filters
        pagerequest:PageUserRequest=new PageUserRequest();
        creationTime:Date[]=[];

        createModalShow:boolean=false;
        editModalShow:boolean=false;
        get list(){
            return this.$store.state.user.list;
        };
        get loading(){
            return this.$store.state.user.loading;
        }
        create(){
            this.createModalShow=true;
        }
      
        pageChange(page:number){
            this.$store.commit('user/setCurrentPage',page);
            this.getpage();
        }
        pagesizeChange(pagesize:number){
            this.$store.commit('user/setPageSize',pagesize);
            this.getpage();
        }
        async getpage(){
          
            this.pagerequest.maxResultCount=this.pageSize;
            this.pagerequest.skipCount=(this.currentPage-1)*this.pageSize;
            //filters
            
            if (this.creationTime.length>0) {
                this.pagerequest.from=this.creationTime[0];
            }
            if (this.creationTime.length>1) {
                this.pagerequest.to=this.creationTime[1];
            }

            await this.$store.dispatch({
                type:'user/getAll',
                data:this.pagerequest
            })
        }
        get pageSize(){
            return this.$store.state.user.pageSize;
        }
        get totalCount(){
            return this.$store.state.user.totalCount;
        }
        get currentPage(){
            return this.$store.state.user.currentPage;
        }
        //是否启用
        selectList =[{          
          label: this.L('All')
        }, {
          value: true,
          label: this.L('Actived')
        }, {
          value:false,
          label: this.L('NoActive')
        }]   

        columns=[{
            title:this.L('UserName'),
            key:'userName'
        },{
            title:this.L('Name'),
            key:'name'
        },{
            title:this.L('IsActive'),
            render:(h:any,params:any)=>{
               return h('span',params.row.isActive?this.L('Yes'):this.L('No'))
            }
        },{
            title:this.L('CreationTime'),
            key:'creationTime',
            render:(h:any,params:any)=>{
                return h('span',new Date(params.row.creationTime).toLocaleDateString())
            }
        },{
            title:this.L('LastLoginTime'),
            render:(h:any,params:any)=>{
                return h('span',new Date(params.row.lastLoginTime).toLocaleString())
            }
        },{
            title:this.L('Actions'),
            key:'Actions',
            width:150,
            render:(h:any,params:any)=>{
                return h('div',[
                    h('Button',{
                        props:{
                            type:'primary',
                            size:'small'
                        },
                        style:{
                            marginRight:'5px'
                        },
                        on:{
                            click:()=>{
                                this.$store.commit('user/edit',params.row);
                                this.edit();
                            }
                        }
                    },this.L('Edit')),
                    h('Button',{
                        props:{
                            type:'error',
                            size:'small'
                        },
                        on:{
                            click:async ()=>{
                                this.$Modal.confirm({
                                        title:this.L('Tips'),
                                        content:this.L('DeleteUserConfirm'),
                                        okText:this.L('Yes'),
                                        cancelText:this.L('No'),
                                        onOk:async()=>{
                                            await this.$store.dispatch({
                                                type:'user/delete',
                                                data:params.row
                                            })
                                            await this.getpage();
                                        }
                                })
                            }
                        }
                    },this.L('Delete'))
                ])
            }
        }]
        async created(){
            this.getpage();
            await this.$store.dispatch({
                type:'user/getRoles'
            })
        }
        formatter(row, column) {
            return new Date(row.creationTime).toLocaleDateString() 
        }
        handleClick(row){
             this.$store.commit('user/edit',row);
             this.edit();
        }
        handleClick_del(row){
             this.$Modal.confirm({
                title:this.L('Tips'),
                content:this.L('DeleteUserConfirm'),
                okText:this.L('Yes'),
                cancelText:this.L('No'),
                onOk:async()=>{
                    await this.$store.dispatch({
                        type:'user/delete',
                        data:row
                    })
                    await this.getpage();
                }
            })
        }
    }
</script>