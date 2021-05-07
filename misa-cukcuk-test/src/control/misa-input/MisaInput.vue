<template>
    <input class="t-input t-input-default" type="text" @input="onInput($event)" :value="value" >
</template>
<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    name: 'misa-input',

    props: {
        label: String,
        type: String,
        format: String,
        required: Boolean
    },

    data() {
        return {
            value: ''
        }
    },

    methods: {
        onInput(event: InputEvent) {
            const input = event.target as HTMLInputElement;
            this.$emit('input', input.value);
        }
    }
})
</script>

<style lang="scss">

.footer .t-input{
    width: 40px;
}
</style>