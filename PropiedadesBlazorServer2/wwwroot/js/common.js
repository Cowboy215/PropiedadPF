
window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operacion Correcta", {timeOut: 10000});
    }

    if (type === "error") {
        toastr.error(message, "Operacion Fallida", { timeOut: 10000 });
    }
}


window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        );
    }

    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        );
    }
}

window.confirmDelete = async () => {
    const result = await Swal.fire({
        title: 'Estas Seguro de borrar?',
        text: "Esto se borrara Permanentemente.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, Eliminalo!',
        cancelButtonText: 'No, Cancelar!',
        reverseButtons: true
    });

    if (result.isConfirmed) {
        Swal.fire("Eliminado", "", "success");
        return result.isConfirmed; 
    } else {
        Swal.fire("Eliminacion Cancelada", "", "info");
        return false;
    }
}

window.showSaveChangesSwal = async () => {
    const result = await Swal.fire({
        title: "Estas Seguro de Borrarlo?",
        showDenyButton: true,
        showCancelButton: true,
        denyButtonText: `No, Eliminar`,
        confirmButtonText: "Eliminar"
        
    });

    if (result.isConfirmed) {
        Swal.fire("Eliminado", "", "success");
        return "eliminado";
    } else if (result.isDenied) {
        Swal.fire("Eliminacion Cancelada", "", "info");
        return "noEliminado";
    } else {
        return "cancelled";
    }
}
