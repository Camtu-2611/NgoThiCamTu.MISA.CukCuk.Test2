<template>
  <input
    class="t-input t-input-default"
    :id="id"
    :type="type"
    @input="$emit('input', $event.target.value)"
    @keypress="$emit('keypress', $event.target.value)"
    @blur="$emit('blur', $event.target.value)"
    :disabled="disabled"
    :value="value"
  />
</template>
<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "misa-input",

  props: {
    label: String,
    type: String,
    format: String,
    required: Boolean,
    value: [String, Number],
    disabled: Boolean,
    id: String,
  },

  // data() {
  //     return {
  //         value: ''
  //     }
  // },

  methods: {
    // onInput(event: InputEvent) {
    //     const input = event.target as HTMLInputElement;
    //     this.$emit('input', input.value);
    // }
  },
});
</script>

<style lang="scss">
.footer .t-input {
  width: 40px;
}
</style>