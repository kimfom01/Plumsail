<template>
    <div class="max-w-md mx-auto mt-8 p-6 bg-white shadow-md rounded">
        <h2 class="text-2xl font-semibold mb-4">Contact Form</h2>
        <form @submit.prevent="handleSubmit">
            <div class="mb-4">
                <label for="name" class="block text-gray-700 text-sm font-bold mb-2">Name:</label>
                <input type="text" id="name" v-model="form.name"
                    class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
                <p v-if="errors.name" class="text-red-500 text-xs italic">
                    {{ errors.name }}
                </p>
            </div>

            <div class="mb-4">
                <label for="email" class="block text-gray-700 text-sm font-bold mb-2">Email:</label>
                <input type="email" id="email" v-model="form.email"
                    class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
                <p v-if="errors.email" class="text-red-500 text-xs italic">
                    {{ errors.email }}
                </p>
            </div>

            <div class="mb-4">
                <label for="message" class="block text-gray-700 text-sm font-bold mb-2">Message:</label>
                <textarea id="message" v-model="form.message"
                    class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"></textarea>
                <p v-if="errors.message" class="text-red-500 text-xs italic">
                    {{ errors.message }}
                </p>
            </div>

            <div class="mb-4">
                <label for="category" class="block text-gray-700 text-sm font-bold mb-2">Category:</label>
                <select id="category" v-model="form.category"
                    class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
                    <option value="">Select a category</option>
                    <option value="question">Question</option>
                    <option value="suggestion">Suggestion</option>
                    <option value="complaint">Complaint</option>
                </select>
                <p v-if="errors.category" class="text-red-500 text-xs italic">
                    {{ errors.category }}
                </p>
            </div>

            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2">Priority:</label>
                <label class="inline-flex items-center mr-4">
                    <input type="radio" value="high" v-model="form.priority" class="form-radio h-5 w-5 text-blue-600" />
                    <span class="ml-2 text-gray-700">High</span>
                </label>
                <label class="inline-flex items-center">
                    <input type="radio" value="low" v-model="form.priority" class="form-radio h-5 w-5 text-blue-600" />
                    <span class="ml-2 text-gray-700">Low</span>
                </label>
                <p v-if="errors.priority" class="text-red-500 text-xs italic">
                    {{ errors.priority }}
                </p>
            </div>

            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2">Subscribe to newsletter?</label>
                <input type="checkbox" v-model="form.subscribe" class="form-checkbox h-5 w-5 text-blue-600" />
            </div>

            <div class="flex items-center justify-between">
                <button
                    class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                    type="submit">
                    Submit
                </button>
            </div>
        </form>
    </div>
</template>

<script lang="ts">
import axios from 'axios';

export default {
    data() {
        return {
            form: {
                name: '',
                email: '',
                message: '',
                category: '',
                priority: null,
                subscribe: false,
            },
            errors: {
                name: '',
                email: '',
                message: '',
                category: '',
                priority: '',
                subscribe: '',
            },
        };
    },
    methods: {
        handleSubmit() {
            this.errors = {
                name: '',
                email: '',
                message: '',
                category: '',
                priority: '',
                subscribe: '',
            };
            if (!this.form.name) {
                this.errors.name = 'Name is required.';
            }
            if (!this.form.email) {
                this.errors.email = 'Email is required.';
            } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(this.form.email)) {
                this.errors.email = 'Invalid email format.';
            }
            if (!this.form.message) {
                this.errors.message = 'Message is required.';
            }
            if (!this.form.category) {
                this.errors.category = 'Category is required.';
            }
            if (!this.form.priority) {
                this.errors.priority = 'Priority is required.';
            }

            if (Object.keys(this.errors).length === 0) {
                // Submit the form
                const stringifiedForm = Object.fromEntries(
                    Object.entries(this.form).map(([key, value]) => [
                        key,
                        String(value), // Convert all values to strings
                    ])
                );

                axios
                    .post('http://localhost:5260/entities/contact', stringifiedForm)
                    .then((response) => {
                        alert('Form submitted successfully!');
                        this.form = {
                            name: '',
                            email: '',
                            message: '',
                            category: '',
                            priority: null,
                            subscribe: false,
                        };
                    })
                    .catch((error) => {
                        console.error('Error submitting form:', error);
                        alert('Error submitting form.');
                    });
            }
        },
    },
};
</script>
