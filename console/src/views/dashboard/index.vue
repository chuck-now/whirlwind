<template>
  <div class="dashboard-container">
    <panel-group />
    <el-row style="background: #fff; padding: 16px 16px 0">
      <line-chart :chart-data="lineChartData" />
    </el-row>
    <el-row style="background: #fff; padding: 16px 16px 0">
      <bar-chat :chart-data="barChartData" />
    </el-row>
  </div>
</template>

<script>
import { queryUserMonthStat, queryOrderMonthStat } from "@/api/bee/stat";
import PanelGroup from "./components/PanelGroup";
import LineChart from "./components/LineChart";
import BarChat from "./components/BarChat";

export default {
  name: "Dashboard",
  components: {
    PanelGroup,
    LineChart,
    BarChat
  },
  data() {
    return {
      lineChartData: {
        keys: [],
        values: []
      },
      barChartData: {
        keys: [],
        values: []
      }
    };
  },
  async mounted() {
    this.bindStat();
  },
  methods: {
    async bindStat() {
      const res = await queryUserMonthStat();
      if (res.isSuccess === true) {
        for (var i in res.result) {
          this.lineChartData.keys.push(res.result[i].date);
          this.lineChartData.values.push(res.result[i].count);
        }
      } else {
        this.$message({
          type: "error",
          message: "数据加载异常!"
        });
      }
      const resOrder = await queryOrderMonthStat();
      if (resOrder.isSuccess === true) {
        for (var order in resOrder.result) {
          this.barChartData.keys.push(resOrder.result[order].date);
          this.barChartData.values.push(resOrder.result[order].count);
        }
      } else {
        this.$message({
          type: "error",
          message: "数据加载异常!"
        });
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.dashboard-container {
  padding: 32px;
  background-color: rgb(240, 242, 245);
  position: relative;

  .chart-wrapper {
    background: #fff;
    padding: 16px 16px 0;
    margin-bottom: 32px;
  }
}

@media (max-width: 1024px) {
  .chart-wrapper {
    padding: 8px;
  }
}
</style>
