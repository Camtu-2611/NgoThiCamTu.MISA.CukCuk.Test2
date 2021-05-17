<template>
    <input
      v-numericOnly
      class="t-input t-input-default"
      :id="id"
      :type="type"
      :value="value"
      @input="$emit('input', $event.target.value)"
      @blur="$emit('blur', $event.target.value)"
    />
</template>

<script >
import Vue from "vue";

Vue.directive("numericOnly", {
  bind(el) {
    el.addEventListener("keyup", () => {
      let regex = /^[0-9]*$/;
      if (!regex.test(el.value)) {
        el.value = el.value.slice(0, -1);
      }
    });
    // el.addEventListener("keyup", ()=>{
    //   el.value = commonFunction.formatMoney(el.value);
    // });
  },
});
export default Vue.extend({
  name: "input-money",
  props: {
    type: String,
    format: String,
    required: Boolean,
    value: [String, Number],
    disabled: Boolean,
    id: String,
  },
  data() {
    return {
      money: {
        decimal: ",",
        thousands: ".",
        prefix: " ",
        suffix: " ",
        precision: 1,
        masked: false,
      },
    };
  },
});
</script>

<style lang="scss" scoped>
.ip-money {
  width: 100%;
  height: 100%;
}
</style>