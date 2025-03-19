<template>
    <div class="container mx-auto mt-8">
        <h2 class="text-2xl font-semibold mb-4">Entities</h2>
        <div v-if="entities && entities.length > 0">
            <div v-for="entity in filteredEntities" :key="entity.id" class="bg-white shadow-md rounded p-4 mb-4">
                <p v-for="(value, key) in entity.data" :key="key">
                    <span class="font-semibold">{{ key }}:</span> {{ value }}
                </p>
            </div>
        </div>
        <div v-else>
            <p>No entities found.</p>
        </div>
    </div>
</template>

<script lang="ts">
import axios from 'axios';

export interface Entity {
  id: number
  owner: string
  data: Data
}

export interface Data {
  name: string
  email: string
  message: string
  category: string
  priority: string
  subscribe: string
}


export default {
    props: {
        searchTerm: {
            type: String,
            default: ''
        }
    },
    data() {
        return {
            entities: [] as Entity[],
            error: null
        };
    },
    mounted() {
        this.fetchEntities();
    },
    computed: {
        filteredEntities() {
            if (!this.searchTerm) {
                return this.entities;
            }

            const lowerSearchTerm = this.searchTerm.toLowerCase();

            return this.entities.filter(entity => {
                return Object.values(entity?.data).some(value => {
                    if (typeof value === 'string') {
                        return value.toLowerCase().includes(lowerSearchTerm);
                    }
                    return false; // Or handle non-string values appropriately
                });
            });
        }
    },
    methods: {
        fetchEntities() {
            axios.get('http://localhost:5260/entities/contact')
                .then(response => {
                    console.table('API Response:', response.data);
                    this.entities = response.data as Entity[];
                })
                .catch(error => {
                    console.error('Error fetching entities:', error);
                    this.error = error.message || 'Failed to fetch entities';
                });
        }
    }
};
</script>
