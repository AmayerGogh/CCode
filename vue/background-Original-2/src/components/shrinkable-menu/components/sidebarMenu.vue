<style lang="less">
    @import '../styles/menu.less';
    .side-bar {
    .el-menu {
      border-right: none;
    }
    .el-menu-vertical-sidebar:not(.el-menu--collapse) {
      width: 200px;
    }

  }

</style>

<template>
     <!-- <Menu ref="sideMenu" :active-name="$route.name" :open-names="openNames" :theme="menuTheme" width="auto" @on-select="changeMenu">
        <template v-for="item in menuList">
            <MenuItem v-if="item.children.length<=0" :name="item.children[0].name" :key="item.name">              
                <span class="iconfont">{{item.icon}}</span>
                <span>{{ itemTitle(item) }}</span>
            </MenuItem>
            <Submenu v-if="item.children.length > 0" :name="item.name" :key="item.name">
                <template slot="title">
                    <i class="iconfont" v-html="item.icon"></i>
                    <span >{{ itemTitle(item) }}</span>
                </template>
                <template v-for="child in item.children">
                   
                    <MenuItem :name="child.name" :key="child.name"> 
                        <i class="iconfont" v-html="child.icon"></i>
                        <span>{{ L(child.meta.title) }}</span>
                    </MenuItem>
                </template>
            </Submenu>
        </template>
    </Menu>  -->
    <div>
        <el-radio-group v-model="isCollapse" style="margin-bottom: 20px;">
            <el-radio-button :label="false">展开</el-radio-button>
            <el-radio-button :label="true">收起</el-radio-button>
        </el-radio-group>
        <el-menu :default-active="$route.name" 
             class="el-menu-vertical-sidebar" 
             @open="handleOpen" 
             @close="handleClose" 
             background-color="#363e4f"
             text-color="hsla(0,0%,100%,.7)"
             active-text-color="#ffd04b"
             :collapse="isCollapse"
             @select="handleSelect">
        <template v-for="item in menuList">
            <el-submenu :index='item.name' :key="item.name">
            <template slot="title">
                <i class="iconfont" v-html="item.icon"></i>
                <span slot="title">{{itemTitle(item)}}</span>
            </template>
            <template v-for="child in item.children">
                <el-menu-item :index="child.name" :key="'menuitem' + child.name">
                {{ L(child.meta.title) }}
                </el-menu-item>
            </template>
            </el-submenu>
        </template>
   
    </el-menu>
    </div>
    
</template>

<script lang="ts">
import { Component, Vue,Inject,Prop,Emit } from 'vue-property-decorator';
import AbpBase from '../../../lib/abpbase'
@Component({})
export default class SidebarMenu extends AbpBase {
    name:string='sidebarMenu';
    @Prop({type:Array}) menuList:Array<any>;
    @Prop({type:Number}) iconSize:number;
    @Prop({type:String,default:'dark'}) menuTheme:string;
    @Prop({type:Array}) openNames:Array<string>;
    @Prop({type:Boolean,default:false}) isCollapse:Boolean;
    itemTitle(item:any):string{
        return this.L(item.meta.title);
    }
    
    beforePush: Function ;
   
    @Emit('on-change')
    changeMenu(active:string){
    }
    updated () {
        this.$nextTick(() => {
            if (this.$refs.sideMenu) {
                (this.$refs.sideMenu as any).updateActiveName();
            }
        });
    }

    handleOpen(key, keyPath) {
      // console.log(key, keyPath);
    }
    handleClose(key, keyPath) {
      // console.log(key, keyPath);
    }
    handleSelect(key, keyPath) {
      let willpush = true;
      if (this.beforePush !== undefined) {
        if (!this.beforePush(name)) {
          willpush = false;
        }
      }
      if (willpush) {
        this.$router.push({
          name: key
        });
      }
    }



}
</script>
