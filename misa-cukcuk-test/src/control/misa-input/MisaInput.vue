<template>
    <input class="t-input t-input-default" :type="type" @input="$emit('input', $event.target.value)" :value="value" >
</template>
<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    name: 'misa-input',

    props: {
        label: String,
        type: String,
        format: String,
        required: Boolean,
        value: [String, Number]
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
    }
})
</script>

<style lang="scss">

.footer .t-input{
    width: 40px;
}
</style>