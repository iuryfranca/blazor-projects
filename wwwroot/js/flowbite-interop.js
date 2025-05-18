window.flowbiteInterop = {
  initializeFlowbite: function () {
    return initFlowbite();
  },

  showModal: function (modalId) {
    const targetEl = document.getElementById(modalId);
    const modal = new Modal(targetEl);
    modal.show();
  },

  closeModal: function (modalId) {
    const targetEl = document.getElementById(modalId);
    const modal = new Modal(targetEl);
    modal.hide();
  },
};
