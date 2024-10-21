<template>
  <div class="app-container">
    <div class="filter-container">
      <el-button icon="el-icon-plus" @click="openCreateForm">添加机器人</el-button>
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
      <el-table-column align="left" label="机器人代码">
        <template slot-scope="{ row }">
          <div>
            {{ row.code }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="left" label="机器人名称">
        <template slot-scope="{ row }">
          <div>
            {{ row.name }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="left" label="描述" width="500">
        <template slot-scope="{ row }">
          <div>
            {{ row.description }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="center" label="任务数">
        <template slot-scope="{ row }">
          <div>
            {{ row.taskCount }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="center" label="操作信息">
        <template slot-scope="{ row }">
          <div>
            {{ row.operatorName }}<br>{{ row.operatorType }}<br>{{ row.operatorAt }}
          </div>
        </template>
      </el-table-column>
      <el-table-column align="center" label="状态">
        <template slot-scope="{ row }">
          <el-switch v-model="row.isEnable" active-color="#13ce66" inactive-color="#ff4949" active-value="Y" inactive-value="N" @change="taggle(row)"></el-switch>
        </template>
      </el-table-column>
      <el-table-column align="center" label="操作">
        <template slot-scope="{ row }">
          <el-button
            icon="el-icon-edit"
            circle
            @click="openEditForm(row)"
          ></el-button>
          <el-button
            slot="reference"
            icon="el-icon-delete"
            circle
            @click="deleteForm(row.id)"
          ></el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-dialog title="新增机器人" :visible.sync="createDialogVisible" width="30%">
      <el-form :model="createInput" :rules="rules" label-width="100px">
        <el-form-item label="机器人名称" prop="name">
          <el-input
            v-model="createInput.name"
            label="left"
            style="width: 50%"
            placeholder="请输入账户机器人名称"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="机器人描述" prop="description">
          <el-input
            v-model="createInput.description"
            type="textarea"
            :rows="6"
            label="left"
            style="width: 50%"
            placeholder="请输入机器人描述"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="createRobot">确 定</el-button>
          <el-button @click="createDialogVisible = false">取 消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>

    <el-dialog title="编辑机器人" :visible.sync="updateDialogVisible" width="30%">
      <el-form :model="updateInput" :rules="rules" label-width="100px">
        <el-form-item label="机器人名称" prop="name">
          <el-input
            v-model="updateInput.name"
            label="left"
            style="width: 50%"
            placeholder="请输入机器人名称"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item label="机器人描述" prop="description">
          <el-input
            v-model="updateInput.description"
            type="textarea"
            :rows="6"
            label="left"
            style="width: 50%"
            placeholder="请输入机器人描述"
            clearable
          ></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="updateRobot">确 定</el-button>
          <el-button @click="updateDialogVisible = false">取 消</el-button>
        </el-form-item>
      </el-form>
    </el-dialog>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import { getAllRobot, createRobot, updateRobot, updateRobotIsEnable, deleteRobot } from "@/api/ayo/robot";

export default {
  name: "RobotList",
  data() {
    return {
      listLoading: false,
      list: [],
      createInput: {
        name: '',
        description: '',
        operatorId: this.operatorId,
        operatorName: this.operatorName
      },
      createDialogVisible: false,
      updateDialogVisible: false,
      updateInput: {
        id: '',
        name: '',
        description: '',
        operatorId: this.operatorId,
        operatorName: this.operatorName
      },
      rules: {
        name: [
          { required: true, message: "机器人名称不能为空", trigger: "blur" }
        ],
        description: [
          { required: true, message: "机器人米搜狐不能为空", trigger: "blur" }
        ]
      }
    };
  },
  computed: {
    ...mapGetters([
      'operatorId',
      'operatorName'
    ])
  },
  async mounted() {
    await this.search()
  },
  methods: {
    async search() {
      this.listLoading = true
      const res = await getAllRobot()
      if (res.isSuccess === true) {
        this.list = res.result == null ? [] : res.result
        this.listLoading = false
      }
    },
    async openCreateForm() {
      this.createDialogVisible = true
      this.createInput.name = ''
      this.createInput.description = ''
    },
    async createRobot() {
      this.createInput.operatorId = this.operatorId
      this.createInput.operatorName = this.operatorName
      const res = await createRobot(this.createInput);
      if (res.isSuccess === true) {
        this.createDialogVisible = false;
        await this.search()
      }
    },
    async openEditForm(row) {
      this.updateDialogVisible = true
      this.updateInput.id = row.id
      this.updateInput.name = row.name
      this.updateInput.description = row.description
    },
    async updateRobot() {
      this.updateInput.operatorId = this.operatorId
      this.updateInput.operatorName = this.operatorName
      const res = await updateRobot(this.updateInput)
      if (res.isSuccess === true) {
        this.updateDialogVisible = false
        await this.search()
      }
    },
    async taggle(row) {
      if (row.id.length === 0) {
        return;
      }
      const taggleinput = {
        id: row.id,
        isEnable: row.isEnable,
        operatorId: this.operatorId,
        operatorName: this.operatorName
      };
      const res = await updateRobotIsEnable(taggleinput);
      if (res.isSuccess === true) {
        console.log("ok")
      }
    },
    async deleteForm(id) {
      if (id.length === 0) {
        return;
      }
      const deleteinput = {
        id: id,
        operatorId: this.operatorId,
        operatorName: this.operatorName
      };
      const res = await deleteRobot(deleteinput);
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
.el-row {
  display: flex;
  flex-wrap: wrap;
}
</style>
