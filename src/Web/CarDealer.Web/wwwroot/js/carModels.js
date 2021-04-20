document.getElementById('makes').addEventListener('click', async (ev) => {
    if (ev.target.tagName == 'LI') {
        const id = ev.target.dataset.value;
        if (id != 'Select make') {
            const modelsDiv = document.getElementById('models');
            modelsDiv.style.display = '';
            const selectElement = document.createElement('select');
            selectElement.setAttribute('name', 'Car.ModelId');
            selectElement.id = 'ModelId';
            selectElement.className = 'nice-select w-100 form-control mt-lg-1 mt-md-2';

            const response = await fetch(`/carmodels/getModels?Id=${id}`);
            const data = await response.json();
            const models = Array.from(data);
            for (let item of models) {
                const option = document.createElement('option');
                option.textContent = item.name;
                option.setAttribute('value', item.id);
                option.className = 'option';
                selectElement.appendChild(option);
            }

            if (modelsDiv.querySelector('select')) {
                modelsDiv.querySelector('select').remove();
                modelsDiv.appendChild(selectElement);
            } else {
                modelsDiv.querySelector('label').style.display = '';
                modelsDiv.appendChild(selectElement);
            }
        }
    }
})