<template>
  <button
    class="t-btn t-btn-default"
    :disabled="disabled"
    @click="btnOnClick($event)"
  >
    <span class="t-btn__icon t-btn__icon-default" :class="icon"></span>
    <span class="t-btn__text">
      <slot></slot>
    </span>
  </button>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: {
    icon: String,
    border: Boolean,
    disabled: Boolean,
  },

  methods: {
    btnOnClick(event: Event) {
      this.$emit("click", event);
    },
  },
});
</script>

<style lang="scss">
@mixin bg-img-btn-footer() {
  background-image: -webkit-gradient(
    linear,
    50% 0,
    50% 100%,
    color-stop(0%, #ededed),
    color-stop(50%, #ebebeb),
    color-stop(51%, #dfdfdf),
    color-stop(100%, #ebebeb)
  );
  background-image: -webkit-linear-gradient(
    top,
    #ededed,
    #ebebeb 50%,
    #dfdfdf 51%,
    #ebebeb
  );
  background-image: -moz-linear-gradient(
    top,
    #ededed,
    #ebebeb 50%,
    #dfdfdf 51%,
    #ebebeb
  );
  background-image: -o-linear-gradient(
    top,
    #ededed,
    #ebebeb 50%,
    #dfdfdf 51%,
    #ebebeb
  );
  background-image: -ms-linear-gradient(
    top,
    #ededed,
    #ebebeb 50%,
    #dfdfdf 51%,
    #ebebeb
  );
  background-image: linear-gradient(
    top,
    #ededed,
    #ebebeb 50%,
    #dfdfdf 51%,
    #ebebeb
  ) !important;
}

.toolbar-btn .t-btn {
  padding: 2px 4px;
  background: none;
  border-color: transparent;

  &:hover {
    background-color: #fff;
  }
}
.feedback-btn .t-btn,
.dialog .t-btn {
  &:hover {
    background-color: #eef6fb;
  }
  &:focus {
    background-color: #eef6fb;
    border-color: #0973b9;
  }
}

.footer__btn .t-btn-default {
  border-radius: 3px !important;
  padding: 3px 3px 3px 3px;
  border-width: 1px;
  border-style: solid;
  background-color: transparent;
  border-color: transparent;

  &:hover {
    border-color: #cecece;
    background-image: -webkit-gradient(
      linear,
      50% 0,
      50% 100%,
      color-stop(0%, #ededed),
      color-stop(50%, #ebebeb),
      color-stop(51%, #dfdfdf),
      color-stop(100%, #ebebeb)
    );
    background-color: #e1e1e1;
  }
}

.footer__btn .t-btn .t-btn__text,
.upfile-button .t-btn .t-btn__text {
  display: none;
}
</style>