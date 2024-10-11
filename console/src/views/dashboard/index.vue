<template>
  <div class="dashboard-container">
  </div>
</template>

<script>

export default {
  name: "Dashboard",
  components: {
  },
  data() {
    return {
    };
  },
  async mounted() {
  },
  methods: {
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
