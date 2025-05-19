window.flowbiteInterop = {
  initializeFlowbite: function () {
    return initFlowbite();
  },

  getModal: function (modalId) {
    const $targetEl = document.getElementById(modalId);

    const options = {
      placement: "center",
      backdrop: "static",
      backdropClasses: "bg-gray-900/50 dark:bg-gray-900/80 fixed inset-0 z-40",
      closable: true,
    };

    const instanceOptions = {
      id: modalId,
      override: true,
    };

    const modal = new Modal($targetEl, options, instanceOptions);
    console.log(modal);
    return modal;
  },

  showModal: function (modalId) {
    const modal = this.getModal(modalId);
    modal.show();
  },

  closeModal: function (modalId) {
    const modal = this.getModal(modalId);
    modal.hide();
  },
};
