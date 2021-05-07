<template>
  <div class="dropdown">
    <select class="t-select" v-model="selectedOption" @input="onSelect($event)">
      <option v-for="option in options" :key="option.value" :value="option.value">
        {{ option.name }}
      </option>
    </select>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: {
    options: Array,
  },
  data() {
    return {
      selectedOption: null,
    };
  },
  methods: {
    onSelect(event: InputEvent) {
      const input = event.target as HTMLInputElement;
      this.$emit("input", input.value);
    },
  },
});
</script>

<style lang="scss">
@import "../../styles/input";
</style>