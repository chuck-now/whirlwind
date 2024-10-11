<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input
        v-model="input.keyword"
        placeholder="请输入账户名称、手机号、邮箱"
        style="width: 200px"
        @keyup.enter.native="search"
      />
      <el-button icon="el-icon-search" @click="search">搜索</el-button>

      <el-button icon="el-icon-plus" @click="openCreateForm">新增</el-button>
    </div>

    <el-table
      v-loading="listLoading"
      :data="list"
      row-key="id"
      style="width: 100%"
      fit
      stripe
      highlight-current-row
    >
      <el-table-column align="left" label="名称">
        <template slot-scope="{ row }">
          <div>
            {{ row.name }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="left" label="邮箱">
        <template slot-scope="{ row }">
          <div>
            {{ row.email }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="left" label="手机号">
        <template slot-scope="{ row }">
          <div>
            {{ row.mobilePhone }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="center" label="创建时间">
        <template slot-scope="{ row }">
          <span>{{ row.createdAt }}</span>
        </template>
      </el-table-column>
      <el-table-column align="center" label="状态">
        <template slot-scope="{ row }">
          <span>
            <el-tag :type="row.tagType">
              {{ row.isDeleted === true ? "删除" : "显示" }}
            </el-tag>
          </span>
        </template>
      </el-table-column>
      <el-table-column align="center" label="操作">
        <template slot-scope="{ row }">
          <el-button
            icon="el-icon-edit"
            circle
            :disabled="row.roles.includes('admin') ? true :false"
            @click="openEditForm(row)"
          ></el-button>
          <el-popconfirm title="确定删除吗？" @onConfirm="deleteForm(row.id)">
            <el-button
              slot="reference"
              icon="el-icon-delete"
              circle
              :disabled="row.roles.includes('admin') ? true :false"
            ></el-button>
          </el-popconfirm>
          <el-button
            :disabled="row.roles.includes('admin') ? true :false"
            size="small"
            @click="openEditPasswordForm(row)"
          >重置密码</el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-row class="text-right">
      <el-col :span="12"></el-col>
      <el-col :span="12">
        <pagination
          v-show="totalCount > 0"
          :total="totalCount"
          :page.sync="input.pageIndex"
          @pagination="search"
        />
      </el-col>
    </el-row>

    <el-dialog title="新增账户" :visible.sync="createDialogVisible" width="30%">
      <el-form :model="createInput" :rules="rules" label-width="100px">
        <el-form-item label="账户名称" prop="name">
          <el-input
            v-model="createInput.name"
            label="left"
            style="width: 50%"
            placeholder="请输入账户名称"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="邮箱" prop="email">
          <el-input
            v-model="createInput.email"
            label="left"
            style="width: 50%"
            placeholder="请输入邮箱地址"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="手机号" prop="mobilePhone">
          <el-input
            v-model="createInput.mobilePhone"
            label="left"
            style="width: 50%"
            placeholder="请输入手机号"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="password">
          <el-input
            v-model="createInput.password"
            label="left"
            style="width: 50%"
            placeholder="请输入密码"
            show-password
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="createAccount">确 定</el-button>
          <el-button @click="createDialogVisible = false">取 消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>

    <el-dialog title="修改账户" :visible.sync="updateDialogVisible" width="30%">
      <el-form :model="updateInput" :rules="rules" label-width="100px">
        <el-form-item label="标签名称" prop="name">
          <el-input
            v-model="updateInput.name"
            label="left"
            style="width: 50%"
            placeholder="请输入标签名称"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="邮箱" prop="email">
          <el-input
            v-model="updateInput.email"
            label="left"
            style="width: 50%"
            placeholder="请输入邮箱地址"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="手机号" prop="mobilePhone">
          <el-input
            v-model="updateInput.mobilePhone"
            label="left"
            style="width: 50%"
            placeholder="请输入手机号"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="updateAccountInfo">确 定</el-button>
          <el-button @click="updateDialogVisible = false">取 消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>

    <el-dialog title="修改账户密码" :visible.sync="updatePasswordDialogVisible" width="30%">
      <el-form :model="updatePasswordInput" :rules="rules" label-width="100px">
        <el-form-item label="密码" prop="password">
          <el-input
            v-model="updatePasswordInput.password"
            label="left"
            style="width: 50%"
            placeholder="请输入密码"
            show-password
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="updateAccountPasswordInfo">确 定</el-button>
          <el-button @click="updatePasswordDialogVisible = false">取 消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
  </div>
</template>

<script>
import {
  queryAccount,
  insertAccount,
  updateAccount,
  updateAccountPassword,
  deleteAccount
} from "@/api/bee/account";
import Pagination from "@/components/Pagination";
import { md5 } from "@/utils/md5";

export default {
  name: "AccountList",
  components: { Pagination },
  data() {
    return {
      listLoading: false,
      input: {
        pageIndex: 1,
        pageSize: 20,
        keyword: ""
      },
      list: [],
      totalCount: 0,
      createInput: {
        name: '',
        email: '',
        mobilePhone: '',
        password: ''
      },
      createDialogVisible: false,
      updateInput: {
        id: '',
        name: '',
        email: '',
        mobilePhone: ''
      },
      updateDialogVisible: false,
      updatePasswordInput: {
        id: '',
        password: ''
      },
      updatePasswordDialogVisible: false,
      rules: {
        name: [
          { required: true, message: "类别名称不能为空", trigger: "blur" }
        ],
        email: [
          { required: true, message: "邮箱不能为空", trigger: "blur" },
          {
            pattern: /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/,
            message: "邮箱格式不正确",
            trigger: "blur"
          }
        ],
        mobilePhone: [
          { required: true, message: "邮箱不能为空", trigger: "blur" },
          {
            pattern:
              /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/,
            message: "手机号格式不正确",
            trigger: "blur"
          }
        ],
        password: [
          { required: true, message: "密码不能为空", trigger: "blur" },
          {
            pattern:
              /^(\w){6,20}$/,
            message: "只能输入6-20个字母、数字、下划线",
            trigger: "blur"
          }
        ]
      }
    };
  },
  async mounted() {
    await this.search();
  },
  methods: {
    async search() {
      this.listLoading = true
      const res = await queryAccount(this.input)
      if (res.isSuccess === true) {
        this.totalCount = res.result.totalCount
        this.list = res.result.items == null ? [] : res.result.items
        this.list.forEach((element) => {
          // 显示tag类型
          if (element.isDeleted === true) {
            element.tagType = "danger"
          } else {
            element.tagType = "success"
          }
        });
        this.listLoading = false
      }
    },
    async openCreateForm() {
      this.createDialogVisible = true
      this.createInput.name = ''
      this.createInput.email = ''
      this.createInput.mobilePhone = ''
    },
    async createAccount() {
      if (
        this.createInput.name === '' ||
        this.createInput.email === '' ||
        this.createInput.mobilePhone === ''
      ) {
        return
      }
      // 邮箱
      const regEmail = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/
      if (!regEmail.test(this.createInput.email)) {
        return
      }
      // 手机号
      const regMobilePhone = /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/
      if (!regMobilePhone.test(this.createInput.mobilePhone)) {
        return
      }
      // 密码
      const regPassword = /^(\w){6,20}$/
      if (!regPassword.test(this.createInput.password)) {
        return
      }
      this.createInput.password = md5(this.createInput.password)
      const res = await insertAccount(this.createInput);
      if (res.isSuccess === true) {
        this.createDialogVisible = false;
        await this.search()
      }
    },
    async openEditForm(row) {
      this.updateDialogVisible = true
      this.updateInput.id = row.id
      this.updateInput.name = row.name
      this.updateInput.email = row.email
      this.updateInput.mobilePhone = row.mobilePhone
    },
    async updateAccountInfo() {
      if (
        this.updateInput.name === '' ||
        this.updateInput.email === '' ||
        this.updateInput.mobilePhone === ''
      ) {
        return
      }
      // 邮箱
      const regEmail = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/
      if (!regEmail.test(this.updateInput.email)) {
        return
      }
      // 手机号
      const regMobilePhone = /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/
      if (!regMobilePhone.test(this.updateInput.mobilePhone)) {
        return
      }
      const res = await updateAccount(this.updateInput)
      if (res.isSuccess === true) {
        this.updateDialogVisible = false
        await this.search()
      }
    },
    async openEditPasswordForm(row) {
      this.updatePasswordDialogVisible = true
      this.updatePasswordInput.id = row.id
      this.updatePasswordInput.password = ''
    },
    async updateAccountPasswordInfo() {
      if (this.updatePasswordInput.password === '') {
        return
      }
      // 密码
      const regPassword = /^(\w){6,20}$/
      if (!regPassword.test(this.updatePasswordInput.mobilePhone)) {
        return
      }

      this.updatePasswordInput.password = md5(this.updatePasswordInput.password)
      const res = await updateAccountPassword(this.updatePasswordInput)
      if (res.isSuccess === true) {
        this.updatePasswordDialogVisible = false
        this.$message({
              type: 'success',
              message: '密码修改成功'
        })
      }
    },
    async deleteForm(id) {
      if (id.length === 0) {
        return;
      }
      const deleteinput = {
        id: id
      };
      const res = await deleteAccount(deleteinput);
      if (res.isSuccess === true) {
        await this.search();
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.app-container {
  margin-top: 50px;
}
.pagination-container {
  padding: 0;
  margin-top: 10px;
}
.el-row {
  display: flex;
  flex-wrap: wrap;
}
</style>
