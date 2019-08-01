<template>
    <!-- <Breadcrumb>
        <BreadcrumbItem 
            v-for="item in currentPath" 
            :to="item" 
            :key="item.name"
        >{{ itemTitle(item) }}</BreadcrumbItem>
    </Breadcrumb> -->
    <el-breadcrumb separator-class="el-icon-arrow-right">
        <el-breadcrumb-item 
         v-for="item in currentPath" 
            :to="item" 
            :key="item.name"
        >{{ itemTitle(item) }}</el-breadcrumb-item>
   
    </el-breadcrumb>
</template>

<script lang="ts">
//ele 面包屑
import { Component, Vue,Inject, Prop } from 'vue-property-decorator';
import AbpBase from '../lib/abpbase'
@Component
export default class extends AbpBase {
    name:string= 'breadcrumbNav';
    @Prop({type:Array}) currentPath:Array<any>;
    itemTitle (item:any) {
        return this.L(item.meta.title);
    }
}
</script>